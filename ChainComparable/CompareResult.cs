using System;
using System.Diagnostics.CodeAnalysis;

namespace ChainComparable
{
    public readonly struct CompareResult<T>
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

        [MaybeNull]
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

        public override bool Equals(
            object? obj)
        {
            if (!(obj is T t))
            {
                return false;
            }

            return this.Equals(t);
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

