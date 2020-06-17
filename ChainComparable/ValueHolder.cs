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
            if (this.Value is null)
            {
                return 0;
            }

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

        public CompareResult<T> InternalEquals(
            [AllowNull] in T other)
        {
            return new CompareResult<T>(_equalityComparer.Equals(this.Value, other), other);
        }

        public CompareResult<T> InternalNotEquals(
            [AllowNull] in T other)
        {
            return this.InternalEquals(other).Negate();
        }

        public CompareResult<T> InternalLessThan(
            [AllowNull] in T other)
        {
            return new CompareResult<T>(_comparer.Compare(this.Value, other) < 0, other);
        }

        public CompareResult<T> InternalGreaterThan(
            [AllowNull] in T other)
        {
            return new CompareResult<T>(_comparer.Compare(this.Value, other) > 0, other);
        }

        public CompareResult<T> InternalLessThanOrEqual(
            [AllowNull] in T other)
        {
            return this.InternalGreaterThan(other).Negate();
        }

        public CompareResult<T> InternalGreaterThanOrEqual(
            [AllowNull] in T other)
        {
            return this.InternalLessThan(other).Negate();
        }

        private static readonly Comparer<T> _comparer = Comparer<T>.Default;

        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
    }
}
