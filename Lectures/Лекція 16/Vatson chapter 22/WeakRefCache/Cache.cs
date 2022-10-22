using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakRefCache
{
    public class Cache<TKey, TValue> where TValue:class
    {
        //store WeakReference instead of TValue, so they can be garbage collected
        private Dictionary<TKey, WeakReference> _cache = new Dictionary<TKey, WeakReference>();

        public void Add(TKey key, TValue value)
        {
            _cache[key] = new WeakReference(value);
        }

        public void Clear()
        {
            _cache.Clear();
        }

        //since dead WeakReference objects could accumulate,
        //you may want to clear them out occasionally
        public void ClearDeadReferences()
        {
            foreach (KeyValuePair<TKey, WeakReference> item in _cache)
            {
                if (!item.Value.IsAlive)
                {
                    _cache.Remove(item.Key);
                }
            }
        }

        public TValue GetObject(TKey key)
        {
            WeakReference reference = null;
            if (_cache.TryGetValue(key, out reference))
            {
                /* Don't check IsAlive first because the GC could kick in right after
                 * anyway. Just retrieve the value and cast it. It will be null
                 * if the object was already collected.
                 * If you succesfully get the Target value, then you'll create a 
                 * strong reference, and prevent it from being garbage collected.
                 */
                return reference.Target as TValue;                
            }
            return null;
        }
    }
}
