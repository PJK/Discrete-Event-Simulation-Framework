using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Object.Queue
{
    public struct QueueElement
    {
        IQueueable _element;
        public IQueueable Element
        {
            get
            {
                return _element;
            }
        }
        uint _blockingTime;
        public uint BlockingTime
        {
            get
            {
                return _blockingTime;
            }
        }

        Flow.Calendar.Term _term;
        public Flow.Calendar.Term Term
        {
            get
            {
                return _term;
            }
        }
        public QueueElement(IQueueable elem, uint btime, Flow.Calendar.Term term)
        {
            _element = elem;
            _blockingTime = btime;
            _term = term;
        }
    }

    public class SimpleQueue : IQueue, Tools.IContextConsumer
    {
        protected List<QueueElement> _elements = new List<QueueElement>();
        protected Tools.SimulationContext _context;
        protected string _uniqueName;
        public string UniqueName
        {
            get
            {
                return _uniqueName;
            }
            set
            {
                _uniqueName = value;
            }
        }

        protected uint _length = 0;

        public uint Length
        {
            get
            {
                return _length;
            }
        }

        public void setContext(Tools.SimulationContext context)
        {
            _context = context;
        }

        public void Notify(Flow.Event.Event ev, Flow.Event.IEventEmmiter source)
        {
            Flow.Event.ReflectiveEventDispatcher.Notify(this, ev, source);
        }

        public void Add(IQueueable elem, uint bloctime)
        {
            Flow.Calendar.Term term = new Flow.Calendar.Term(_context.Calendar.Time + bloctime + _length, this, "ElementEjected", null);
            _elements.Add(new QueueElement(elem, bloctime,term));
            _context.Calendar.AddTerm(term);
            _length += bloctime;
        }

        public void Remove(IQueueable queuer)
        {
            List<QueueElement> origElems = _elements;
            _elements = new List<QueueElement>();
            // will look up the element in local register and then reconstruct the calendar terms
            foreach (QueueElement elem in origElems)
            {
                    if (elem.Element != queuer)
                    {
                        //neat code reuse :]
                        Add(elem.Element, elem.BlockingTime);
                    }

            }
        }

        public uint MembersCount
        {
            get
            {
                return (uint)_elements.Count;
            }
        }

    }
}
