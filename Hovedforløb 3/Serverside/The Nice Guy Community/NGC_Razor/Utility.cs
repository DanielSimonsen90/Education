using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CortosoUniversity
{
    public static class Utility
    {
#if SQLiteVersion
        public static string GetLastChars(this byte[] token) => token.ToString().Substring(0..^3)
#else
        public static string GetLastChars(this byte[] token) => token[7].ToString();
#endif
    }
}
