using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace DESF.Tools
{
    public class ObjectRepository
    {
        protected Hashtable _data = new Hashtable();

        public void Set(string key, object item)
        {
            _data[key] = item;
        }

        public T Get<T>(string key)
        {
            if (_data[key] is T)
            {
                return (T)_data[key];
            }
            else
            {
                throw new ArgumentException("Requested item has different type that the referenced one!");
            }
        }

    }
}
