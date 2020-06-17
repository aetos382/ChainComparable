using System;
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
            this._valueHolder = new ValueHolder<T>(value);
        }

        public T Value
        {
            [return: MaybeNull]
            get
            {
                return this._valueHolder.Value;
            }
        }

        public override string ToString()
        {
            return this._valueHolder.ToString();
        }

        public override bool Equals(
            object? obj)
        {
            return this._valueHolder.Equals(obj);
        }

#pragma warning disable IDE0070

        public override int GetHashCode()
        {
            return this._valueHolder.GetHashCode();
        }

#pragma warning restore IDE0070

        public bool Equals(
            [AllowNull] T other)
        {
            return this._valueHolder.Equals(other);
        }

        public int CompareTo(
            [AllowNull] T other)
        {
            return this._valueHolder.CompareTo(other);
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
            return left._valueHolder.InternalEquals(right);
        }

        public static CompareResult<T> operator !=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalNotEquals(right);
        }

        public static CompareResult<T> operator <(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalLessThan(right);
        }

        public static CompareResult<T> operator >(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalGreaterThan(right);
        }

        public static CompareResult<T> operator <=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalLessThanOrEqual(right);
        }
        
        public static CompareResult<T> operator >=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalGreaterThanOrEqual(right);
        }

        private readonly ValueHolder<T> _valueHolder;
    }
}
