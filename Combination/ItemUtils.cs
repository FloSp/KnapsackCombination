using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    public interface IItemUtils<T>
    {
        Length getItemLength(T item);

        double getItemValue(T item);

        int getItemMaxCount(T item);

        bool areCombinable(IEnumerable<T> items);
    }
}
