using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    public static class KnappsackCombiner
    {

        public static IEnumerable<ICombination<T>> CompleteCombination<T>(ICombination<T> initialCombination,
                                                                          IEnumerable<T> newItems,
                                                                          Func<T, Length> getItemLength,
                                                                          Func<T, double> getItemValue,
                                                                          Func<T, int> getItemMaxCount,
                                                                          Func<IEnumerable<T>, bool> areCombinable)
        {

           var availableItems= new Sor
                newItems.SelectMany((item => Enumerable.Repeat(item, getItemMaxCount(item)));
           var optimalValues = new Dictionary<>

        }


        
        

    }
}
