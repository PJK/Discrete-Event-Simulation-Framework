using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Object.Queue
{
    /// <summary>
    /// Internal representation of queue element
    /// </summary>
    public struct QueueElement
    {
        IQueueable _element;

        /// <summary>
        /// Reference to the queued element
        /// </summary>
        public IQueueable Element
        {
            get
            {
                return _element;
            }
        }

        uint _blockingTime;

        /// <summary>
        /// How long will element proccessing hold rest of the queue
        /// </summary>
        public uint BlockingTime
        {
            get
            {
                return _blockingTime;
            }
        }

        Flow.Calendar.Term _term;

        /// <summary>
        /// Term created for queue invocation
        /// </summary>
        public Flow.Calendar.Term Term
        {
            get
            {
                return _term;
            }
        }

        uint _timeCame;
        public uint TimeCame
        {
            get
            {
                return _timeCame;
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="elem">Object to be queued</param>
        /// <param name="btime">Time it will take to finish it's buissines</param>
        /// <param name="term">Term created for calendar callback</param>
        public QueueElement(IQueueable elem, uint btime, uint timecame, Flow.Calendar.Term term)
        {
            _element = elem;
            _blockingTime = btime;
            _timeCame = timecame;
            _term = term;
        }
    }


    /// <summary>
    /// Simply a queue without special features
    /// </summary>
    public class SimpleQueue : IQueue, Tools.IContextConsumer
    {
        /// <summary>
        /// List of QueueElements in the queue
        /// </summary>
        protected List<QueueElement> _elements = new List<QueueElement>();

        /// <summary>
        /// Context the queue is working in
        /// </summary>
        protected Tools.SimulationContext _context;

        /// <summary>
        /// Unique name to be displayed in logs
        /// </summary>
        protected string _uniqueName;

        /// <summary>
        /// Log name setter & getter
        /// </summary>
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

        /// <summary>
        /// Length, in meaning of time newcoming entities will have to wait
        /// </summary>
        protected uint _length = 0;

        /// <summary>
        /// Length, in meaning of time newcoming entities will have to wait
        /// </summary>
        public uint Length
        {
            get
            {
                return _length;
            }
        }

        /// <summary>
        /// Number of queued entities
        /// </summary>
        public uint MembersCount
        {
            get
            {
                return (uint)_elements.Count;
            }
        }

        /// <summary>
        /// Inject context to work in
        /// </summary>
        /// <param name="context">The context</param>
        public void setContext(Tools.SimulationContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Notify the queue manager about global events
        /// </summary>
        /// <param name="ev">Incoming event</param>
        /// <param name="source">Event emmiter</param>
        public void Notify(Flow.Event.Event ev, Flow.Event.IEventEmmiter source)
        {
            Flow.Event.ReflectiveEventDispatcher.Notify(this, ev, source);
        }

        /// <summary>
        /// Add a new entitity to the queue
        /// </summary>
        /// <param name="elem">The queueing entity</param>
        /// <param name="bloctime">Time the entity will block others</param>
        public void Add(IQueueable elem, uint bloctime)
        {
            Flow.Calendar.Term term = new Flow.Calendar.Term(_context.Calendar.Time + _length, this, "ElementEjected", null);
            _elements.Add(new QueueElement(elem, bloctime, _context.Calendar.Time, term));
            _context.Calendar.AddTerm(term);
            _length += bloctime;
        }

        /// <summary>
        /// Withdraws the element from the queue before its' schedule. Reorders left queuers
        /// </summary>
        /// <param name="queuer">The entity to be dropped</param>
        public void Remove(IQueueable queuer)
        {
            List<QueueElement> origElems = _elements;
            bool first = true;
            _elements = new List<QueueElement>();
            // will look up the element in local register and then reconstruct the calendar terms
            foreach (QueueElement elem in origElems)
            {
                if (first)
                {
                    if (!(elem.Element == queuer))
                    {
                        Add(elem.Element, elem.BlockingTime - _context.Calendar.Time + elem.TimeCame);
                    }
                }
                else
                {
                    if (elem.Element != queuer)
                    {
                        //neat code reuse :]
                        Add(elem.Element, elem.BlockingTime);
                    }
                }
            }
        }

    }
}
