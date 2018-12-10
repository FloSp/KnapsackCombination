using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Extensions;

namespace Combination
{
    public static class KnappsackCombiner
    {

        public static IEnumerable<ICombination<T>> CompleteCombination<T>(ICombination<T> initialCombination,
                                                                          IEnumerable<T> newItems,
                                                                          IItemUtils<T> itemMethods,
                                                                          Length totalLength)
        {
            var sortedItems = newItems.SelectMany(item => item.ToSequence(itemMethods.getItemMaxCount(item))).ToSortedList();

            var optimalValues = new Dictionary<(int, Length), double>();

            sortedItems.ToList().ForEach(item => ComputeOptimalValues(item, itemMethods, optimalValues, totalLength));

            return GetCombinationFromTable(initialCombination, optimalValues, sortedItems, itemMethods.getItemLength).ToSequence();
        }


        private static void ComputeOptimalValues<T>(KeyValuePair<int, T> item, IItemUtils<T> itemMethods, Dictionary<(int, Length), double> optimalValues, Length totalLength)
        {
            for (Length currentLength = 0; currentLength <= totalLength; currentLength++)
            {
                var itemLength = itemMethods.getItemLength(item.Value);
                var itemValue = itemMethods.getItemValue(item.Value);

                if (currentLength < itemLength)
                {
                    optimalValues[(item.Key, currentLength)] = 0;
                    continue;
                }

                if (item.Key == 0 && itemLength <= currentLength)
                {
                    optimalValues[(item.Key, currentLength)] = itemValue;
                    continue;
                }

                if (itemLength <= currentLength)
                {
                   var x1 = (item.Key - 1, currentLength - itemLength).GetHashCode();
                   var x2= optimalValues[(item.Key - 1, currentLength - itemLength)];
                   var x3= optimalValues[(item.Key - 1, currentLength)];
                    optimalValues[(item.Key, currentLength)] = Math.Max(itemMethods.getItemValue(item.Value) + optimalValues[(item.Key - 1, currentLength - itemLength)], optimalValues[(item.Key - 1, currentLength)]);
                }
            }
        }


        private static ICombination<T> GetCombinationFromTable<T>(ICombination<T> initialCombination, Dictionary<(int row, Length column), double> optimalValues, SortedList<int, T> items, Func<T, Length> getItemLength)
        {
            var currentColumn = optimalValues.Keys.Select(tuple => tuple.column).Max();

            for (int currentRow = optimalValues.Keys.Select(tuple => tuple.row).Max(); currentRow >= 0; currentRow--)
            {
                if (IsItemInKnapsack(currentRow ,currentColumn, optimalValues))
                {
                    initialCombination = initialCombination.Add(items[currentRow], 1);
                    currentColumn -= getItemLength(items[currentRow]);
                }

            }
            return initialCombination;
        }

        private static bool IsItemInKnapsack(int currentRow, Length currentColumn, Dictionary<(int row, Length column), double> values)
        {
            if (currentRow == 0)
            {
                return values[(currentRow, currentColumn)] > 0;
            }

            return values[(currentRow, currentColumn)] > values[(currentRow - 1, currentColumn)];
        }
    }
}
