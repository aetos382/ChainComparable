#pragma warning disable CA1066
#pragma warning disable CA2225

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ChainComparable
{
    public readonly struct ChainComparableValue<T> :
        IEquatable<T>,
        IComparable<T>
        where T : IComparable<T>
    {
        public ChainComparableValue(
            [AllowNull] T value)
        {
            this.Value = value;
        }

        [AllowNull]
        // ReSharper disable once MemberCanBePrivate.Global
        public T Value
        {
            [return: MaybeNull]
            [DebuggerStepThrough]
            get;
        }

        public override string ToString()
        {
            return this.Value?.ToString() ?? string.Empty;
        }

        public override bool Equals(
            object? obj)
        {
            if (obj is null)
            {
                return this.Value is null;
            }

            return
                (obj is T other) &&
                ChainComparer<T>.InternalEquals(this.Value, other).Result;
        }

        public override int GetHashCode()
        {
            return ChainComparer<T>.InternalGetHashCode(this.Value);
        }

        public bool Equals(
            [AllowNull] T other)
        {
            return ChainComparer<T>.InternalEquals(this.Value, other).Result;
        }

        public int CompareTo(
            [AllowNull] T other)
        {
            return ChainComparer<T>.InternalCompare(this.Value, other);
        }

        [return: MaybeNull]
        public static implicit operator T(
            in ChainComparableValue<T> value)
        {
            return value.Value;
        }

        public static CompareResult<T> operator ==(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalEquals(left.Value, right);
        }

        public static CompareResult<T> operator ==(
            [AllowNull] in T left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalEquals(left, right.Value);
        }

        public static CompareResult<T> operator ==(
            in ChainComparableValue<T> left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalEquals(left.Value, right.Value);
        }

        public static CompareResult<T> operator !=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalNotEquals(left.Value, right);
        }

        public static CompareResult<T> operator !=(
            [AllowNull] in T left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalNotEquals(left, right.Value);
        }

        public static CompareResult<T> operator !=(
            in ChainComparableValue<T> left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalNotEquals(left.Value, right.Value);
        }

        public static CompareResult<T> operator <(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalLessThan(left.Value, right);
        }

        public static CompareResult<T> operator <(
            [AllowNull] in T left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalLessThan(left, right.Value);
        }

        public static CompareResult<T> operator <(
            in ChainComparableValue<T> left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalLessThan(left.Value, right.Value);
        }

        public static CompareResult<T> operator >(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalGreaterThan(left.Value, right);
        }

        public static CompareResult<T> operator >(
            [AllowNull] in T left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalGreaterThan(left, right.Value);
        }

        public static CompareResult<T> operator >(
            in ChainComparableValue<T> left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalGreaterThan(left.Value, right.Value);
        }

        public static CompareResult<T> operator <=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalLessThanOrEqual(left.Value, right);
        }

        public static CompareResult<T> operator <=(
            [AllowNull] in T left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalLessThanOrEqual(left, right.Value);
        }

        public static CompareResult<T> operator <=(
            in ChainComparableValue<T> left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalLessThanOrEqual(left.Value, right.Value);
        }

        public static CompareResult<T> operator >=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalGreaterThanOrEqual(left.Value, right);
        }

        public static CompareResult<T> operator >=(
            [AllowNull] in T left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalGreaterThanOrEqual(left, right.Value);
        }

        public static CompareResult<T> operator >=(
            in ChainComparableValue<T> left,
            in ChainComparableValue<T> right)
        {
            return ChainComparer<T>.InternalGreaterThanOrEqual(left.Value, right.Value);
        }
    }
}
