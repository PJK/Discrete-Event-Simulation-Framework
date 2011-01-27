using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DESF.Flow.Calendar
{
    public class Term
    {
        protected uint _time;
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

        public Term(uint time, string state, HashSet<string> data)
        {
            _time = time;
            _state = state;
            _data = data;
        }
    }
}
