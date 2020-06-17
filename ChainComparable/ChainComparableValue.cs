using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

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

        [return: MaybeNull]
        public static implicit operator T(
            ChainComparableValue<T> value)
        {
            return value.Value;
        }

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
            return HashCode.Combine(this.Value);
        }

        public bool Equals(
            [AllowNull] T other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(
            [AllowNull] T other)
        {
            return Comparer.SafeCompare(this.Value, other);
        }

        public static CompareResult<T> operator ==(
            ChainComparableValue<T> left,
            [AllowNull] T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.Value, right) == 0, right);
        }

        public static CompareResult<T> operator !=(
            ChainComparableValue<T> left,
            [AllowNull] T right)
        {
            return (left == right).Negate();
        }

        public static CompareResult<T> operator <(
            ChainComparableValue<T> left,
            [AllowNull] T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.Value, right) < 0, right);
        }

        public static CompareResult<T> operator >(
            ChainComparableValue<T> left,
            [AllowNull] T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.Value, right) > 0, right);
        }

        public static CompareResult<T> operator <=(
            ChainComparableValue<T> left,
            [AllowNull] T right)
        {
            return (left > right).Negate();
        }
        
        public static CompareResult<T> operator >=(
            ChainComparableValue<T> left,
            [AllowNull] T right)
        {
            return (left < right).Negate();
        }
    }
}
