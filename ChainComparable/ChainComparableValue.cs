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

            if (value is null)
            {
                this._stringValue = string.Empty;
            }
            else
            {
                this._stringValue = value.ToString();
            }
        }

        [AllowNull]
        [MaybeNull]
        public T Value
        {
            get
            {
                return this._valueHolder.Value;
            }
        }

        private readonly string _stringValue;

        public override string ToString()
        {
            return this._stringValue;
        }

        public override bool Equals(
            object? obj)
        {
            return this._valueHolder.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this._valueHolder.GetHashCode();
        }

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
            return left._valueHolder == right;
        }

        public static CompareResult<T> operator !=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder != right;
        }

        public static CompareResult<T> operator <(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder < right;
        }

        public static CompareResult<T> operator >(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder > right;
        }

        public static CompareResult<T> operator <=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder <= right;
        }
        
        public static CompareResult<T> operator >=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder >= right;
        }

        private readonly ValueHolder<T> _valueHolder;
    }
}
