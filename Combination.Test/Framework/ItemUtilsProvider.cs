using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination.Test.Framework
{
    public class ItemUtilsProvider : IItemUtils<Item>
    {
        public bool areCombinable(IEnumerable<Item> items)
        {
            return true;
        }

        public Length getItemLength(Item item)
        {
            return item.Weight;
        }

        public int getItemMaxCount(Item item)
        {
            return item.MaxCount;
        }

        public double getItemValue(Item item)
        {
            return item.Value;
        }
    }
}
