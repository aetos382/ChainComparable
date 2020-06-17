﻿using System;
using System.Runtime.CompilerServices;

namespace ChainComparable
{
    public readonly struct ChainComparableValue<T> :
        IEquatable<T>,
        IComparable<T>
        where T : IComparable<T>
    {
        public ChainComparableValue(
            T value)
        {
            this.Value = value;

            if (value is {})
            {
                this._stringValue = value.ToString();
            }
            else
            {
                this._stringValue = string.Empty;
            }
        }

        public T Value { get; }

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
            if (!(obj is ChainComparableValue<T> other))
            {
                return false;
            }

            return this.Equals(other);
        }

        public override int GetHashCode()
        {
            return RuntimeHelpers.GetHashCode(this.Value);
        }

        public bool Equals(
            T other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(
            T other)
        {
            return Comparer.SafeCompare(this.Value, other);
        }

        public static CompareResult<T> operator ==(
            ChainComparableValue<T> left,
            T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.Value, right) == 0, right);
        }

        public static CompareResult<T> operator !=(
            ChainComparableValue<T> left,
            T right)
        {
            return (left == right).Negate();
        }

        public static CompareResult<T> operator <(
            ChainComparableValue<T> left,
            T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.Value, right) < 0, right);
        }

        public static CompareResult<T> operator >(
            ChainComparableValue<T> left,
            T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.Value, right) > 0, right);
        }

        public static CompareResult<T> operator <=(
            ChainComparableValue<T> left,
            T right)
        {
            return (left > right).Negate();
        }
        
        public static CompareResult<T> operator >=(
            ChainComparableValue<T> left,
            T right)
        {
            return (left < right).Negate();
        }
    }
}
