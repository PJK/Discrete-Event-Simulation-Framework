using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Calendar
{
    public class Term : IComparable
    {
        protected uint _time;
        protected Event.IEventHandler _owner;
        protected string _state;
        protected HashSet<string> _data;
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

        public HashSet<string> Data
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

        public Term(uint time, Event.IEventHandler owner, string state, HashSet<string> data)
        {
            _time = time;
            _owner = owner;
            _state = state;
            _data = data;
        }

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
    }
}
