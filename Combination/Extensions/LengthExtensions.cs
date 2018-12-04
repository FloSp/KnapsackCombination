using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination.Extensions
{
    public static class LengthExtensions
    {
        /// <summary>
        /// Calculates the sum of a sequence.
        /// </summary>
        /// <typeparam name="T">T type</typeparam>
        /// <param name="sequence">sequence</param>
        /// <param name="getLength">length</param>
        /// <returns>The sum</returns>
        public static Length Sum<T>(this IEnumerable<T> sequence, Func<T, Length> getLength)
        {
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            return sequence.Select(getLength).Aggregate(default(Length), (length1, length2) => length1 + length2);
        }
    }
}
