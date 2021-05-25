using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLintro
{
    public static class Extensions
    {
        public static List<T> Filter<T>(this List<T> list, Func<T, bool> callback)
        {
            List<T> result = new List<T>();
            foreach (var item in list)
            {
                if (callback(item))
                    result.Add(item);
            }
            return result;
        }
        public static List<T> ForEach<T>(this List<T> list, Action<T> action)
        {
            foreach (var item in list)
                action(item);
            return list;
        }
        public static Dictionary<TKey, TValue> Set<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            if (dictionary.ContainsKey(key))
                dictionary.Remove(key);
            dictionary.Add(key, value);

            return dictionary;
        }
    }
}
