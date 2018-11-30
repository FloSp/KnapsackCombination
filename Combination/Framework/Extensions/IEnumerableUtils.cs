using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Extensions
{
    public static class IEnumerableUtils
    {
        static IEnumerable<T> ToSequence<T>(this T item, int count = 1) => Enumerable.Repeat(item, count);
    }
}
