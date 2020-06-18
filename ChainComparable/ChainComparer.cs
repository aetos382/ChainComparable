#pragma warning disable CA1000

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ChainComparable
{
    public static class ChainComparer<T>
        where T : IComparable<T>
    {
        public static readonly IEqualityComparer<T> DefaultEqualityComparer = EqualityComparer<T>.Default;

        private static IEqualityComparer<T> _equalityComparer = DefaultEqualityComparer;

        public static IEqualityComparer<T> EqualityComparer
        {
            get
            {
                return _equalityComparer;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _equalityComparer = value;
            }
        }

        public static readonly IComparer<T> DefaultComparer = Comparer<T>.Default;

        private static IComparer<T> _comparer = DefaultComparer;

        public static IComparer<T> Comparer
        {
            get
            {
                return _comparer;
            }

            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException(nameof(value));
                }

                _comparer = value;
            }
        }

        internal static int InternalGetHashCode(
            [AllowNull] in T obj)
        {
            if (obj is null)
            {
                return 0;
            }

            return _equalityComparer.GetHashCode(obj);
        }

        internal static CompareResult<T> InternalEquals(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
#pragma warning disable CS8604 // false positive

            return new CompareResult<T>(
                _equalityComparer.Equals(left, right),
                left, right);

#pragma warning restore CS8604
        }

        internal static int InternalCompare(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
#pragma warning disable CS8604 // false positive

            return _comparer.Compare(left, right);

#pragma warning restore CS8604
        }

        internal static CompareResult<T> InternalNotEquals(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
            return InternalEquals(left, right).Negate();
        }

        internal static CompareResult<T> InternalLessThan(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(
                InternalCompare(left, right) < 0,
                left,
                right);
        }

        internal static CompareResult<T> InternalGreaterThan(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(
                InternalCompare(left, right) > 0,
                left,
                right);
        }

        internal static CompareResult<T> InternalLessThanOrEqual(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
            return InternalGreaterThan(left, right).Negate();
        }

        internal static CompareResult<T> InternalGreaterThanOrEqual(
            [AllowNull] in T left,
            [AllowNull] in T right)
        {
            return InternalLessThan(left, right).Negate();
        }
    }
}
