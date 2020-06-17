using System;
using System.Diagnostics.CodeAnalysis;

namespace ChainComparable
{
    public readonly struct CompareResult<T> :
        IEquatable<T>,
        IComparable<T>
        where T : IComparable<T>
    {
        public CompareResult(
            bool result,
            [AllowNull] T rightClause)
        {
            this.Result = result;
            this.RightClause = rightClause;
        }

        public bool Result { get; }

        [AllowNull]
        public T RightClause { get; }

        public static implicit operator bool(
            CompareResult<T> result)
        {
            return result.Result;
        }

        [return: MaybeNull]
        public static implicit operator T(
            CompareResult<T> result)
        {
            return result.RightClause;
        }

        public CompareResult<T> Negate()
        {
            return new CompareResult<T>(!this.Result, this.RightClause);
        }

        public static CompareResult<T> operator !(
            CompareResult<T> result)
        {
            return result.Negate();
        }

        public bool Equals(
            [AllowNull] T other)
        {
            return this.CompareTo(other) == 0;
        }

        public int CompareTo(
            [AllowNull] T other)
        {
            return Comparer.SafeCompare(this.RightClause, other);
        }

        public override bool Equals(
            object? obj)
        {
            if (obj is null)
            {
                return this.RightClause is null;
            }

            return (obj is T other) && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Result, this.RightClause);
        }

        public static CompareResult<T> operator ==(
            CompareResult<T> left,
            [AllowNull] T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.RightClause, right) == 0, right);
        }

        public static CompareResult<T> operator !=(
            CompareResult<T> left,
            [AllowNull] T right)
        {
            return (left == right).Negate();
        }

        public static CompareResult<T> operator <(
            CompareResult<T> left,
            [AllowNull] T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.RightClause, right) < 0, right);
        }

        public static CompareResult<T> operator >(
            CompareResult<T> left,
            [AllowNull] T right)
        {
            return new CompareResult<T>(Comparer.SafeCompare(left.RightClause, right) > 0, right);
        }

        public static CompareResult<T> operator <=(
            CompareResult<T> left,
            [AllowNull] T right)
        {
            return (left > right).Negate();
        }

        public static CompareResult<T> operator >=(
            CompareResult<T> left,
            [AllowNull] T right)
        {
            return (left < right).Negate();
        }
    }
}

