using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Combination.Extensions;

namespace Combination.Test.Framework
{
    /// <inheritdoc/>
    public class ItemCombination : ICombination<Item>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemCombination"/> class.
        /// abc
        /// </summary>
        /// <param name="items">aa</param>
        private ItemCombination(IImmutableDictionary<Item, int> items)
        {
            this.Items = items as ImmutableDictionary<Item, int>;
        }

        private ItemCombination()
        {
            this.Items = ImmutableDictionary<Item, int>.Empty;
        }

        /// <summary>
        /// Gets the Items.
        /// </summary>
        public ImmutableDictionary<Item, int> Items { get; }

        /// <summary>
        /// Returns a Empty Combination.
        /// </summary>
        /// <returns>A empty combination</returns>
        public static ICombination<Item> Empty()
        {
            return new ItemCombination();
        }

        /// <inheritdoc/>
        public ICombination<Item> Add(Item x, int n)
        {
            if (n < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(n));
            }

            if (this.Items.TryGetValue(x, out int val))
            {
                return new ItemCombination(this.Items.SetItem(x, n + val));
            }

            return new ItemCombination(this.Items.Add(x, n));
        }

        /// <inheritdoc/>
        public bool CanAdd(Item x, int n)
        {
            return true;
        }

        /// <summary>
        /// Gets the length of the combination.
        /// </summary>
        /// <param name="getItemLength">Item Length</param>
        /// <returns>The sum of the lengths of all items in the combination</returns>
        public Length GetLength(Func<Item, Length> getItemLength)
        {
            return this.Items.Sum(itemWithCount => itemWithCount.Value * getItemLength(itemWithCount.Key));
        }
    }
}
