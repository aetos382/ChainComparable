using System;
using System.Collections.Generic;
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
            this.RightTerm = rightClause;
        }

        public bool Result { get; }

        [AllowNull]
        [MaybeNull]
        public T RightTerm { get; }

        public CompareResult<T> Negate()
        {
            return new CompareResult<T>(!this.Result, this.RightTerm);
        }
        
        public bool Equals(
            [AllowNull] T other)
        {
            return _equalityComparer.Equals(this.RightTerm, other);
        }

        public int CompareTo(
            [AllowNull] T other)
        {
            return _comparer.Compare(this.RightTerm, other);
        }

        public override bool Equals(
            object? obj)
        {
            if (obj is null)
            {
                return this.RightTerm is null;
            }

            return (obj is T other) && this.Equals(other);
        }

        public override int GetHashCode()
        {
            return _equalityComparer.GetHashCode(this.RightTerm);
        }
        
        public static implicit operator bool(
            in CompareResult<T> result)
        {
            return result.Result;
        }

        [return: MaybeNull]
        public static implicit operator T(
            in CompareResult<T> result)
        {
            return result.RightTerm;
        }
        
        public static CompareResult<T> operator !(
            in CompareResult<T> result)
        {
            return result.Negate();
        }

        public static CompareResult<T> operator ==(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_equalityComparer.Equals(left.RightTerm, right), right);
        }

        public static CompareResult<T> operator !=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return !(left == right);
        }

        public static CompareResult<T> operator <(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_comparer.Compare(left.RightTerm, right) < 0, right);
        }

        public static CompareResult<T> operator >(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return new CompareResult<T>(_comparer.Compare(left.RightTerm, right) > 0, right);
        }

        public static CompareResult<T> operator <=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return !(left > right);
        }

        public static CompareResult<T> operator >=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return !(left < right);
        }

        private static readonly Comparer<T> _comparer = Comparer<T>.Default;

        private static readonly EqualityComparer<T> _equalityComparer = EqualityComparer<T>.Default;
    }
}
