using System;
using System.Collections.Immutable;

namespace Combination
{
    public interface ICombination<T>
    {
        ImmutableDictionary<T, int> Items { get; }

        Length GetLength(Func<T, Length> getItemLength);

        ICombination<T> Add(T item, int itemCount);
    }
}
