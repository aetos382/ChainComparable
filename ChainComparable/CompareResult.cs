#pragma warning disable CS0660
#pragma warning disable CS0661
#pragma warning disable CA1815
#pragma warning disable CA2225

using System;
using System.ComponentModel;
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
            [AllowNull] T rightValue,
            ComparisonOperator comparisonOperator)
        {
            this.Result = result;
            this.LeftValue = leftValue;
            this.RightValue = rightValue;
            this.Operator = comparisonOperator;

            this._stringForm = ToString(
                result,
                leftValue,
                rightValue,
                comparisonOperator);
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

        public ComparisonOperator Operator
        {
            [DebuggerStepThrough]
            get;
        }

        public CompareResult<T> Negate()
        {
#pragma warning disable CA1303

            var negatedOperator = this.Operator switch {
                ComparisonOperator.Equality => ComparisonOperator.Inequality,
                ComparisonOperator.Inequality => ComparisonOperator.Equality,
                ComparisonOperator.LessThan => ComparisonOperator.GreaterThanOrEqual,
                ComparisonOperator.GreaterThan => ComparisonOperator.LessThanOrEqual,
                ComparisonOperator.LessThanOrEqual => ComparisonOperator.GreaterThan,
                ComparisonOperator.GreaterThanOrEqual => ComparisonOperator.LessThan,

                _ => throw new InvalidOperationException("Invalid operator")
            };

#pragma warning restore CA1303

            return new CompareResult<T>(
                !this.Result,
                this.LeftValue,
                this.RightValue,
                negatedOperator);
        }

        private static string ToString(
            bool result,
            [AllowNull] in T leftValue,
            [AllowNull] in T rightValue,
            ComparisonOperator comparisonOperator)
        {
            string operatorString = comparisonOperator switch {
                ComparisonOperator.Equality => "==",
                ComparisonOperator.Inequality => "!=",
                ComparisonOperator.LessThan => "<",
                ComparisonOperator.GreaterThan => ">",
                ComparisonOperator.LessThanOrEqual => "<=",
                ComparisonOperator.GreaterThanOrEqual => ">=",

                _ => throw new InvalidEnumArgumentException(
                    nameof(comparisonOperator),
                    (int) comparisonOperator,
                    typeof(ComparisonOperator))
            };

            string stringForm = $"{result} ({leftValue} {operatorString} {rightValue})";
            return stringForm;
        }

        private readonly string _stringForm;

        public override string ToString()
        {
            return this._stringForm;
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
