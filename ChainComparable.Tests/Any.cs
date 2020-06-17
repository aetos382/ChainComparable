using System.Diagnostics.CodeAnalysis;

namespace ChainComparable.Tests
{
    internal static class Any<T>
    {
        [MaybeNull]
        public static readonly T Value = default;
    }
}
