using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebserver
{
    public static class Extender
    {
        public static string Combine<T>(this IList<T> arr, string seperator)
        {
            StringBuilder sb = new();

            foreach (var item in arr)
                sb.Append(item.ToString() + seperator);

            return sb.ToString();
        }
    }
}
