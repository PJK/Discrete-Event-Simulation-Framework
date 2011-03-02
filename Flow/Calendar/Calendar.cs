using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using DESF.Tools;

namespace DESF.Flow.Calendar
{
    /// <summary>
    /// The heart of simulation proccess. Registers and invokes
    /// terms, triggers "global" events and manages queues.
    /// </summary>
    public class Calendar : Event.IEventEmmiter, Subject.Logger.ILogContributor, Tools.IContextConsumer
    {
        /// <summary>
        /// Holds all upcoming terms
        /// </summary>
        protected List<Term> _terms = new List<Term>();

        /// <summary>
        /// The current simulation time
        /// </summary>
        protected uint _time = 0;

        protected string _uniqueName = "Calendar";

        /// <summary>
        /// Current simulation context
        /// </summary>
        protected Tools.SimulationContext _context;

        /// <summary>
        /// Manager of subscribers
        /// </summary>
        protected Event.EventEmmitingProvider _provider = new Event.EventEmmitingProvider();

        public string UniqueName
        {
            get
            { return _uniqueName; }
        }

        public uint Time
        {
            get
            {
                return _time;
            }
        }

        public Calendar(Tools.SimulationContext context)
        {
            setContext(context);
        }

        public void setContext(Tools.SimulationContext context)
        {
            _context = context;
        }

        public bool HasSimulationStarted;

        /// <summary>
        /// Attaches a new subscriber. This basically means that 
        /// the subscriber enters the simulation
        /// </summary>
        /// <param name="handler">Subscriber</param>
        public void AttachHandler(Event.IEventHandler handler)
        {
            _context.Logger.Log(this, "Attached a new handler: " + LoggingHelpers.GetTypeOrName(handler), 5);
            _provider.AttachHandler(handler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handlers"></param>
        public void AttachHandler(Event.IEventHandler[] handlers)
        {
            foreach (Event.IEventHandler handler in handlers)
            {
                AttachHandler(handler);
            }
        }

        /// <summary>
        /// Detaches subsriber
        /// </summary>
        /// <param name="handler">Subscriber</param>
        public void DetachHandler(Event.IEventHandler handler)
        {
            _context.Logger.Log(this, "Detached a handler: " + LoggingHelpers.GetTypeOrName(handler), 5);
            _provider.DetachHandler(handler);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="handlers"></param>
        public void DetachHandler(Event.IEventHandler[] handlers)
        {
            foreach (Event.IEventHandler handler in handlers)
            {
                DetachHandler(handler);
            }
        }

        /// <summary>
        /// Add a new term for invocation
        /// </summary>
        /// <param name="term">The term</param>
        public void AddTerm(Term term)
        {
            _context.Logger.Log(this, String.Format("Adding a new term (time: {0}, state {1}, owner {2})", term.Time, term.State, LoggingHelpers.GetTypeOrName(term.Owner)), 10);
            if (term.Time < _time)
            {
                throw new ArgumentException("It's not possible to add a term based in past!");
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

        /// <summary>
        /// Invokes a term
        /// </summary>
        /// <param name="term">The term</param>
        protected void InvokeTerm(Term term)
        {
            _time = term.Time;
            _context.Logger.Log(this, String.Format("Invoking a term (time: {0}, state {1}, owner {2})", term.Time, term.State, LoggingHelpers.GetTypeOrName(term.Owner)), 1);
            term.Owner.Notify(new Event.Event(term.State, term.Data), this);
        }

        public void RemoveTerm(Term term)
        {
            _context.Logger.Log(this, String.Format("Removing a term (time: {0}, state {1}, owner {2})", term.Time, term.State, LoggingHelpers.GetTypeOrName(term.Owner)), 10);
            foreach (Term t in _terms)
            {
                if (t.EqualsTo(term))
                {
                    _terms.Remove(t);
                }
            }
        }

        public void RemoveTermsByOwner(Flow.Event.IEventHandler owner)
        {
            foreach (Term t in _terms)
            {
                if (t.Owner == owner)
                {
                    _terms.Remove(t);
                }
            }
        }

        /// <summary>
        /// Starts the simulation by triggering the "SimulationStarted" event
        /// </summary>
        public void StartSimulation()
        {
            _context.Logger.Log(this, "Starting up the simulation", 1);
            _provider.FireEvent(new Event.Event("SimulationStarted", null), this);
            HasSimulationStarted = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public void StopSimulation()
        {
            _context.Logger.Log(this, "Sending SimulationStopped signal", 1);
            _provider.FireEvent(new Event.Event("SimulationStopped", null), this);
            _terms =  new List<Term>();
        }

        public bool HasNextTerm()
        {
            return _terms.Count > 0;
        }

        /// <summary>
        /// Moves simulation to the next hop
        /// </summary>
        public void Procceed()
        {
            if (!HasSimulationStarted)
            {
                throw new System.InvalidOperationException("Cannot procceed when the simulation hasn't started yet! Are you so fucking dumb?");
            }
            if (_terms.Count == 0)
            {
                throw new System.InvalidOperationException("No term to invoke. In your face!");
            }
            _terms.Sort();
            uint otime = _terms[0].Time;
            while ((_terms.Count > 0) && (_terms[0].Time == otime))
            {
                Term tcache = _terms[0];
                _terms.RemoveAt(0);
                InvokeTerm(tcache);
            }
        }
    }
}
