using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace DESF.Tools
{
    /// <summary>
    /// Repository of typed objects. Great for passing various
    /// groups and collections around. Associative array (hash)
    /// with built-in unboxing.
    /// </summary>
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
