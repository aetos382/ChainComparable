using System;
using System.Globalization;

namespace ChainComparable
{
    public interface IMyInt
    {
        int Value { get; }
    }

    public readonly struct MyInt :
        IMyInt,
        IEquatable<IMyInt>,
        IComparable<IMyInt>
    {
        public MyInt(
            int value)
        {
            this.Value = value;
            this._stringValue = value.ToString(CultureInfo.CurrentCulture);
        }

        public int Value { get; }

        private readonly string _stringValue;

        public override bool Equals(
            object? obj)
        {
            if (!(obj is MyInt m))
            {
                return false;
            }

            return this.Equals(m);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public override string ToString()
        {
            return this._stringValue;
        }

        public bool Equals(IMyInt other)
        {
            if (other is null)
            {
                return false;
            }

            return this.Value == other.Value;
        }

        public int CompareTo(IMyInt other)
        {
            if (other is null)
            {
                return 1;
            }

            return this.Value - other.Value;
        }

        public static CompareResult operator ==(MyInt left, IMyInt right)
        {
            return new CompareResult(left.Value == right.Value, right);
        }

        public static CompareResult operator !=(MyInt left, IMyInt right)
        {
            return (left == right).Negate();
        }

        public static CompareResult operator <(MyInt left, IMyInt right)
        {
            return new CompareResult(left.Value < right.Value, right);
        }

        public static CompareResult operator >(MyInt left, IMyInt right)
        {
            return new CompareResult(left.Value > right.Value, right);
        }

        public static CompareResult operator <=(MyInt left, IMyInt right)
        {
            return (left > right).Negate();
        }
                        
        public static CompareResult operator >=(MyInt left, IMyInt right)
        {
            return (left < right).Negate();
        }

        public struct CompareResult :
            IMyInt,
            IEquatable<IMyInt>,
            IComparable<IMyInt>
        {
            public CompareResult(
                bool result,
                IMyInt rightClause)
            {
                this.Result = result;
                this.RightClause = rightClause;
            }

            public bool Result { get; }

            public IMyInt RightClause { get; }

            public static implicit operator bool(CompareResult result)
            {
                return result.Result;
            }

            public CompareResult Negate()
            {
                return new CompareResult(!this.Result, this.RightClause);
            }

            public int Value
            {
                get
                {
                    return this.RightClause.Value;
                }
            }

            public bool Equals(IMyInt other)
            {
                if (other is null)
                {
                    return false;
                }

                return this.Value == other.Value;
            }

            public int CompareTo(IMyInt other)
            {
                if (other is null)
                {
                    return 1;
                }

                return this.Value - other.Value;
            }

            public static CompareResult operator ==(CompareResult left, IMyInt right)
            {
                return new CompareResult(left.Value == right.Value, right);
            }

            public static CompareResult operator !=(CompareResult left, IMyInt right)
            {
                return (left == right).Negate();
            }

            public static CompareResult operator <(CompareResult left, IMyInt right)
            {
                return new CompareResult(left.Value < right.Value, right);
            }

            public static CompareResult operator >(CompareResult left, IMyInt right)
            {
                return new CompareResult(left.Value > right.Value, right);
            }

            public static CompareResult operator <=(CompareResult left, IMyInt right)
            {
                return (left > right).Negate();
            }
                            
            public static CompareResult operator >=(CompareResult left, IMyInt right)
            {
                return (left < right).Negate();
            }
        }
    }
}
