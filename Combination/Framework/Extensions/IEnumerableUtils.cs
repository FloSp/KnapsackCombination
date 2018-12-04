using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    public static class IEnumerableUtils
    {
        public static IEnumerable<T> ToSequence<T>(this T item, int count = 1) => Enumerable.Repeat(item, count);

        public static SortedList<int, T> ToSortedList<T>(this IEnumerable<T> sequence)
        {
            return new SortedList<int, T>(sequence.Select((x, i) => new KeyValuePair<int, T>(i, x)).ToDictionary(pair=> pair.Key, pair=> pair.Value));
        }
    }

}
