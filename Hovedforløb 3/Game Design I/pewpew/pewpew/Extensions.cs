using System.Collections.Generic;
using System.Text;

namespace pewpew
{
    public static class Extensions
    {
        public static List<char> AddFor(this List<char> self, char value, int length)
        {
            for (int i = 0; i < length; i++)
                self.Add(value);
            return self;
        }
        public static List<char> LongestCharArr(this List<List<char>> self)
        {
            List<char> longestItem = self[0];

            foreach (List<char> arr in self)
                if (arr.Count > longestItem.Count)
                    longestItem = arr;

            return longestItem;
        }
    }
}
