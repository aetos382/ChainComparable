using System;
using System.Collections.Generic;
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
        public T Value { get; }

        private readonly string _stringValue;

        public override string ToString()
        {
            return this._stringValue;
        }

        public override bool Equals(
            object? obj)
        {
            if (obj is null)
            {
                return this.Value is null;
            }

            return (obj is T other) && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this.Value);
        }

        public bool Equals(
            [AllowNull] T other)
        {
            return _equalityComparer.Equals(this.Value, other);
        }

        public int CompareTo(
            [AllowNull] T other)
        {
            return _comparer.Compare(this.Value, other);
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
            return new CompareResult<T>(_equalityComparer.Equals(left.Value, right), right);
        }

        public static CompareResult<T> operator !=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return !(left == right);
        }

        public static CompareResult<T> operator <(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_comparer.Compare(left.Value, right) < 0, right);
        }

        public static CompareResult<T> operator >(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_comparer.Compare(left.Value, right) > 0, right);
        }

        public static CompareResult<T> operator <=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return !(left > right);
        }
        
        public static CompareResult<T> operator >=(
            in ChainComparableValue<T> left,
            [AllowNull] in T right)
        {
            return !(left < right);
        }

        private static readonly Comparer<T> _comparer = Comparer<T>.Default;

        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
    }
}
