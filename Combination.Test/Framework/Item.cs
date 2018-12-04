using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination.Test.Framework
{
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="weight">Weigth</param>
        public Item(int value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }

        /// <summary>
        /// Gets Value of a Item.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Gets Weigth of a item.
        /// </summary>
        public int Weight { get; }

        /// <summary>
        /// Deconstruct.
        /// </summary>
        /// <param name="value">Value</param>
        /// <param name="weight">Weight</param>
        public void Deconstruct(out int value, out int weight)
        {
            weight = this.Weight;
            value = this.Value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return "Value: " + this.Value.ToString() + "Weigth:" + this.Weight.ToString();
        }
    }
}
