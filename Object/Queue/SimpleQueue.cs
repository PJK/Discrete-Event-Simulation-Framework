using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Object.Queue
{
    public struct QueueElement
    {
        IQueueable Element;
        uint BlockingTime;
        public QueueElement(IQueueable elem, uint btime)
        {
            Element = elem;
            BlockingTime = btime;
        }
    }

    public class SimpleQueue : IQueue, Tools.IContextConsumer
    {
        protected HashSet<QueueElement> _elements = new HashSet<QueueElement>();
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

        public void Notify(Flow.Event.SEvent ev, Flow.Event.IEventEmmiter source)
        {
            Flow.Event.ReflectiveEventDispatcher.Notify(this, ev, source);
        }

        public void Add(IQueueable elem, uint bloctime)
        {
            _elements.Add(new QueueElement(elem, bloctime));
            HashSet<string> data = new HashSet<string>();
            _context.Calendar.AddTerm(new Flow.Calendar.Term(_context.Calendar.Time + bloctime + _length, this, "ElementRejected", data));
            _length += bloctime;
        }

        public void Remove(IQueueable elem)
        {
            //td: implement
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
