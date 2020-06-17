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
            [AllowNull] T rightTerm)
        {
            this.Result = result;
            this._valueHolder = new ValueHolder<T>(rightTerm);
        }

        public bool Result { get; }

        public T RightTerm
        {
            [return: MaybeNull]
            get
            {
                return this._valueHolder.Value;
            }
        }

        public CompareResult<T> Negate()
        {
            return new CompareResult<T>(!this.Result, this.RightTerm);
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
            return left._valueHolder.InternalEquals(right);
        }

        public static CompareResult<T> operator !=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalNotEquals(right);
        }

        public static CompareResult<T> operator <(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalLessThan(right);
        }

        public static CompareResult<T> operator >(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalGreaterThan(right);
        }

        public static CompareResult<T> operator <=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalLessThanOrEqual(right);
        }

        public static CompareResult<T> operator >=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return left._valueHolder.InternalGreaterThanOrEqual(right);
        }

        private readonly ValueHolder<T> _valueHolder;
    }
}
