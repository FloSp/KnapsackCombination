using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Extensions;

namespace Combination
{
    public static class KnappsackCombiner
    {

        public static IEnumerable<ICombination<T>> CompleteCombination<T>(ICombination<T> initialCombination,
                                                                          IEnumerable<T> newItems,
                                                                          Func<T, Length> getItemLength,
                                                                          Func<T, double> getItemValue,
                                                                          Func<T, int> getItemMaxCount,
                                                                          Length totalLength,
                                                                          Func<IEnumerable<T>, bool> areCombinable)
        {

            var sortedItems = newItems.SelectMany(item => item.ToSequence(getItemMaxCount(item))).ToSortedList();
            var values = new Dictionary<(int, Length), double>();

            sortedItems.ToList().ForEach(item => GetValuesForCapacity(item));

           void GetValuesForCapacity(KeyValuePair<int, T> item)
            {
                for(Length currentLength = 0; currentLength <= totalLength; currentLength++)
                {
                    var itemLength = getItemLength(item.Value);
                    var itemValue = getItemValue(item.Value);

                    if (currentLength == 0)
                    {
                        values[(item.Key, currentLength)] = 0;
                        continue;
                    }

                    if(item.Key == 0 && itemLength <= currentLength)
                    {
                        values[(item.Key, currentLength)] =  itemValue;
                        continue;
                    }

                    if(itemLength <= currentLength)
                    {
                        values[(item.Key, currentLength)] = Math.Max(getItemValue(item.Value) + values[(item.Key - 1, currentLength - itemLength)], values[(item.Key - 1, currentLength)]);
                    }

                }

            };

            return GetCombinationFromTable(initialCombination, values, sortedItems, getItemLength).ToSequence();
        }

        private static ICombination<T> GetCombinationFromTable<T>(ICombination<T> initialCombination, Dictionary<(int row, Length column), double> values, SortedList<int, T> items, Func<T, Length> getItemLength)
        {
            var currentColumn = values.Keys.Select(tuple => tuple.column).Max();

            for (int currentRow = values.Keys.Select(tuple => tuple.row).Max(); currentRow >= 0; currentRow--)
            {
                if (IsItemInKnapsack(currentRow ,currentColumn,values))
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
