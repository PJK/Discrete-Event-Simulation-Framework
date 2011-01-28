using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

namespace DESF.Flow.Calendar
{
    /// <summary>
    /// The heart of simulation proccess. Registers and invokes
    /// terms, triggers "global" events and manages queues.
    /// </summary>
    public class Calendar : Event.IEventEmmiter, Subject.Logger.ILogContributor, Tools.IContextConsumer
    {

        protected List<Term> _terms = new List<Term>();
        protected uint _time = 0;
        protected string _uniqueName = "Calendar";
        protected Tools.SimulationContext _context;
        public string UniqueName
        {
            get
            { return _uniqueName; }
        }

        public Calendar(Tools.SimulationContext context)
        {
            setContext(context);
        }

        public void setContext(Tools.SimulationContext context)
        {
            _context = context;
        }

        protected Event.EventEmmitingProvider _provider = new Event.EventEmmitingProvider();

        public void AttachHandler(Event.IEventHandler handler)
        {
            _context.Logger.Log(this, "Attached new handler: " + handler.GetType(), 5);
            _provider.AttachHandler(handler);
        }

        public void DetachHandler(Event.IEventHandler handler)
        {
            _provider.DetachHandler(handler);
        }

        public void AddTerm(Term term)
        {
            if (term.Time < _time)
            {
                throw new ArgumentException("It's not possible to add term based in past!");
            }
            else if (term.Time == _time)
            {
                InvokeTerm(term);
            }
            else
            {
                _terms.Add(term);
            }
        }

        protected void InvokeTerm(Term term)
        {
            _time = term.Time;
            term.Owner.Notify(new Event.SEvent(term.State, term.Data), this);
        }

        public void StartSimulation()
        {
            _provider.FireEvent(new Event.SEvent("SimulationStarted", null), this);
        }

        public void StopSimulation()
        {
            _provider.FireEvent(new Event.SEvent("SimulationStopped", null), this);
        }

        public bool HasNextTerm()
        {
            return _terms.Count > 0;
        }

        public void Procceed()
        {
            _terms.Sort();
            uint otime = _terms[0].Time;
            while (_terms[0].Time == otime)
            {
                Term tcache = _terms[0];
                _terms.RemoveAt(0);
                InvokeTerm(tcache);
            }
        }
    }
}
