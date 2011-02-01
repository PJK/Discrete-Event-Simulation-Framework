using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Calendar
{
    /// <summary>
    /// Represents a term in the simulation calendar
    /// </summary>
    public class Term : IComparable
    {
        /// <summary>
        /// Current simulation time
        /// </summary>
        protected uint _time;

        /// <summary>
        /// Reference to object that had set this term
        /// </summary>
        protected Event.IEventHandler _owner;

        /// <summary>
        /// State (event) to invoke
        /// </summary>
        protected string _state;

        /// <summary>
        /// Data to be passed alongside
        /// </summary>
        protected object[] _data;

        public uint Time
        {
            get
            {
                return _time;
            }
            protected set
            {
                throw new AccessViolationException("Term is locked for modifications!");
            }
        }


        public Event.IEventHandler Owner
        {
            get
            {
                return _owner;
            }
            protected set
            {
                throw new AccessViolationException("Term is locked for modifications!");
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                throw new AccessViolationException("Term is locked for modifications!");
            }
        }

        public object[] Data
        {
            get
            {
                return _data;
            }
            set
            {
                throw new AccessViolationException("Term is locked for modifications!");
            }
        }

        public Term(uint time, Event.IEventHandler owner, string state, object[] data)
        {
            _time = time;
            _owner = owner;
            _state = state;
            _data = data;
        }

        /// <summary>
        /// Comparison method with standart signature
        /// </summary>
        /// <param name="arg">Reference object</param>
        /// <returns>{-1,0,1}</returns>
        public int CompareTo(object arg)
        {
            Term what = (Term)arg;
            if (this.Time > what.Time)
            {
                return 1;
            }
            else if (this.Time == what.Time)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public bool EqualsTo(Term t)
        {
            return (t.Data == Data) && (t.Owner == Owner) && (t.State == State) && (t.Time == Time);
        }
    }
}
