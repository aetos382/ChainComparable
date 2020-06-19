#pragma warning disable CS0660
#pragma warning disable CS0661
#pragma warning disable CA1815
#pragma warning disable CA2225

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace ChainComparable
{
    public readonly struct CompareResult<T>
        where T : IComparable<T>
    {
        public CompareResult(
            bool result,
            [AllowNull] T leftValue,
            [AllowNull] T rightValue)
        {
            this.Result = result;
            this.LeftValue = leftValue;
            this.RightValue = rightValue;
        }

        public bool Result
        {
            [DebuggerStepThrough]
            get;
        }

        [AllowNull]
        // ReSharper disable once MemberCanBePrivate.Global
        public T LeftValue
        {
            [return: MaybeNull]
            [DebuggerStepThrough]
            get;
        }

        [AllowNull]
        // ReSharper disable once MemberCanBePrivate.Global
        public T RightValue
        {
            [return: MaybeNull]
            [DebuggerStepThrough]
            get;
        }

        public CompareResult<T> Negate()
        {
            return new CompareResult<T>(
                !this.Result,
                this.LeftValue,
                this.RightValue);
        }
        
        public static implicit operator bool(
            in CompareResult<T> result)
        {
            return result.Result;
        }

        public static CompareResult<T> operator ==(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalEquals(left.RightValue, right);
        }

        public static CompareResult<T> operator ==(
            [AllowNull] in T left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalEquals(left, right.LeftValue);
        }

        public static CompareResult<T> operator ==(
            in CompareResult<T> left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalEquals(left.RightValue, right.LeftValue);
        }

        public static CompareResult<T> operator !=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalNotEquals(left.RightValue, right);
        }

        public static CompareResult<T> operator !=(
            [AllowNull] in T left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalNotEquals(left, right.LeftValue);
        }

        public static CompareResult<T> operator !=(
            in CompareResult<T> left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalNotEquals(left.RightValue, right.LeftValue);
        }

        public static CompareResult<T> operator <(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalLessThan(left.RightValue, right);
        }

        public static CompareResult<T> operator <(
            [AllowNull] in T left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalLessThan(left, right.LeftValue);
        }

        public static CompareResult<T> operator <(
            in CompareResult<T> left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalLessThan(left.RightValue, right.LeftValue);
        }

        public static CompareResult<T> operator >(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalGreaterThan(left.RightValue, right);
        }

        public static CompareResult<T> operator >(
            [AllowNull] in T left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalGreaterThan(left, right.LeftValue);
        }

        public static CompareResult<T> operator >(
            in CompareResult<T> left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalGreaterThan(left.RightValue, right.LeftValue);
        }

        public static CompareResult<T> operator <=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalLessThanOrEqual(left.RightValue, right);
        }

        public static CompareResult<T> operator <=(
            [AllowNull] in T left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalLessThanOrEqual(left, right.LeftValue);
        }

        public static CompareResult<T> operator <=(
            in CompareResult<T> left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalLessThanOrEqual(left.RightValue, right.LeftValue);
        }

        public static CompareResult<T> operator >=(
            in CompareResult<T> left,
            [AllowNull] in T right)
        {
            return ChainComparer<T>.InternalGreaterThanOrEqual(left.RightValue, right);
        }

        public static CompareResult<T> operator >=(
            [AllowNull] in T left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalGreaterThanOrEqual(left, right.LeftValue);
        }

        public static CompareResult<T> operator >=(
            in CompareResult<T> left,
            in CompareResult<T> right)
        {
            return ChainComparer<T>.InternalGreaterThanOrEqual(left.RightValue, right.LeftValue);
        }
    }
}
