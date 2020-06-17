using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ChainComparable
{
    internal readonly struct ValueHolder<T> :
        IEquatable<T>,
        IComparable<T>
        where T : IComparable<T>
    {
        public ValueHolder(
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
        [MaybeNull]
        public T Value { get; }

        private readonly string _stringValue;

        public override string ToString()
        {
            return this._stringValue;
        }

#pragma warning disable IDE0070

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this.Value);
        }

#pragma warning restore IDE0070

        public override bool Equals(
            object? obj)
        {
            if (obj is null)
            {
                return this.Value is null;
            }

            return (obj is T other) && this.Equals(other);
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

        public static CompareResult<T> operator ==(
            in ValueHolder<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_equalityComparer.Equals(left.Value, right), right);
        }

        public static CompareResult<T> operator !=(
            in ValueHolder<T> left,
            [AllowNull] in T right)
        {
            return !(left == right);
        }

        public static CompareResult<T> operator <(
            in ValueHolder<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_comparer.Compare(left.Value, right) < 0, right);
        }

        public static CompareResult<T> operator >(
            in ValueHolder<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_comparer.Compare(left.Value, right) > 0, right);
        }

        public static CompareResult<T> operator <=(
            in ValueHolder<T> left,
            [AllowNull] in T right)
        {
            return !(left > right);
        }

        public static CompareResult<T> operator >=(
            in ValueHolder<T> left,
            [AllowNull] in T right)
        {
            return !(left < right);
        }

        private static readonly Comparer<T> _comparer = Comparer<T>.Default;

        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
    }
}
