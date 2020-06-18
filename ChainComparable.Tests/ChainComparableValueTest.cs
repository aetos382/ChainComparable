﻿#pragma warning disable CA1707

using Xunit;

namespace ChainComparable.Tests
{
    public class ChainComparableValueTest
    {
        [Fact]
        public void 二項等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);

            Assert.True(a == b);
        }

        [Fact]
        public void 二項等値演算_左がT()
        {
            var a = 1;
            var b = new ChainComparableValue<int>(1);

            Assert.True(a == b);
        }

        [Fact]
        public void 二項等値演算_右がT()
        {
            var a = new ChainComparableValue<int>(1);
            var b = 1;

            Assert.True(a == b);
        }

        [Fact]
        public void 二項非等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

            Assert.True(a != b);
        }

        [Fact]
        public void 二項非等値演算_左がT()
        {
            var a = 1;
            var b = new ChainComparableValue<int>(2);

            Assert.True(a != b);
        }

        [Fact]
        public void 二項非等値演算_右がT()
        {
            var a = new ChainComparableValue<int>(1);
            var b = 2;

            Assert.True(a != b);
        }

        [Fact]
        public void 二項小なり演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

            Assert.True(a < b);
        }

        [Fact]
        public void 二項小なり演算_左がT()
        {
            var a = 1;
            var b = new ChainComparableValue<int>(2);

            Assert.True(a < b);
        }

        [Fact]
        public void 二項小なり演算_右がT()
        {
            var a = new ChainComparableValue<int>(1);
            var b = 2;

            Assert.True(a < b);
        }

        [Fact]
        public void 二項大なり演算()
        {
            var a = new ChainComparableValue<int>(2);
            var b = new ChainComparableValue<int>(1);

            Assert.True(a > b);
        }

        [Fact]
        public void 二項大なり演算_左がT()
        {
            var a = 2;
            var b = new ChainComparableValue<int>(1);

            Assert.True(a > b);
        }

        [Fact]
        public void 二項大なり演算_右がT()
        {
            var a = new ChainComparableValue<int>(2);
            var b = 1;

            Assert.True(a > b);
        }

        [Fact]
        public void 二項小なり等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

            Assert.True(a <= b);
        }

        [Fact]
        public void 二項小なり等値演算_左がT()
        {
            var a = 1;
            var b = new ChainComparableValue<int>(2);

            Assert.True(a <= b);
        }

        [Fact]
        public void 二項小なり等値演算_右がT()
        {
            var a = new ChainComparableValue<int>(1);
            var b = 2;

            Assert.True(a <= b);
        }

        [Fact]
        public void 二項大なり等値演算()
        {
            var a = new ChainComparableValue<int>(2);
            var b = new ChainComparableValue<int>(1);

            Assert.True(a >= b);
        }

        [Fact]
        public void 二項大なり等値演算_左がT()
        {
            var a = 2;
            var b = new ChainComparableValue<int>(1);

            Assert.True(a >= b);
        }

        [Fact]
        public void 二項大なり等値演算_右がT()
        {
            var a = new ChainComparableValue<int>(2);
            var b = 1;

            Assert.True(a >= b);
        }

        [Fact]
        public void 三項小なり演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a < b < c);
            Assert.True(a < b && b < c);
        }

        [Fact]
        public void 三項大なり演算()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a > b > c);
            Assert.True(a > b && b > c);
        }

        [Fact]
        public void 三項等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a == b == c);
            Assert.True(a == b && b == c);
        }

        [Fact]
        public void 三項等値_不等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(2);

            Assert.True(a == b != c);
            Assert.True(a == b && b != c);
        }

        [Fact]
        public void 三項小なり等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a <= b <= c);
            Assert.True(a <= b && b <= c);
        }

        [Fact]
        public void 三項大なり等値演算()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a >= b >= c);
            Assert.True(a >= b && b >= c);
        }

        [Fact]
        public void 三項大なり_小なり演算()
        {
            var a = new ChainComparableValue<int>(4);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(5);

            Assert.True(a > b < c);
            Assert.True(a > b && b < c);
        }

        [Fact]
        public void 三項小なり演算_カッコつき()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a < (b < c));
            Assert.True(a < b && b < c);
        }

        [Fact]
        public void 三項大なり演算_カッコつき()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a > (b > c));
            Assert.True(a > b && b > c);
        }

        [Fact]
        public void 三項等値演算_カッコつき()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a == (b == c));
            Assert.True(a == b && b == c);
        }

        [Fact]
        public void 三項小なり_大なり演算_カッコつき()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(5);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a < (b > c));
            Assert.True(a < b && b > c);
        }

        [Fact]
        public void Tにキャストしてみる()
        {
            var value = new ChainComparableValue<int>(100);

            Assert.Equal(100, value);
        }

        [Fact]
        public void Equalsのテスト()
        {
            var value = new ChainComparableValue<int>(100);

            Assert.False(value.Equals(99));
            Assert.True(value.Equals(100));
            Assert.False(value.Equals(101));
        }

        [Fact]
        public void Equals_objectのテスト()
        {
            var value = new ChainComparableValue<int>(100);

            Assert.False(value.Equals((object)99));
            Assert.True(value.Equals((object)100));
            Assert.False(value.Equals((object)101));
        }

        [Fact]
        public void Equalsでnullとnull以外を比較すると等しくない()
        {
            var nullValue = new ChainComparableValue<string>(null);
            var nonNullValue = new ChainComparableValue<string>(string.Empty);

            Assert.False(nonNullValue.Equals(null));
            Assert.False(nullValue.Equals(string.Empty));
        }

        [Fact]
        public void Equals_objectでnullとnull以外を比較すると等しくない()
        {
            var nullValue = new ChainComparableValue<string>(null);
            var nonNullValue = new ChainComparableValue<string>(string.Empty);

            Assert.False(nonNullValue.Equals((object)null));
            Assert.False(nullValue.Equals((object)string.Empty));
        }

        [Fact]
        public void Equalsでnull同士を比較すると等しい()
        {
            var value = new ChainComparableValue<string>(null);

            Assert.True(value.Equals(null));
        }

        [Fact]
        public void Equals_objectでnull同士を比較すると等しい()
        {
            var value = new ChainComparableValue<string>(null);

            Assert.True(value.Equals((object)null));
        }

        [Fact]
        public void CompareToのテスト()
        {
            var value = new ChainComparableValue<int>(100);

            Assert.True(value.CompareTo(99) > 0);
            Assert.True(value.CompareTo(100) == 0);
            Assert.True(value.CompareTo(99) > 0);
        }

        [Fact]
        public void CompareToでnullとnull以外の値を比較するとnullは最小値とみなされる()
        {
            var nullValue = new ChainComparableValue<string>(null);
            var nonNullValue = new ChainComparableValue<string>(string.Empty);

            Assert.True(nonNullValue.CompareTo(null) > 0);
            Assert.True(nullValue.CompareTo(string.Empty) < 0);
        }

        [Fact]
        public void CompareToでnull同士を比較すると等しい()
        {
            var value = new ChainComparableValue<string>(null);

            Assert.Equal(0, value.CompareTo(null));
        }

        [Fact]
        public void GetHashCodeが成功する()
        {
            var value = new ChainComparableValue<string>(Any<string>.Value);

            value.GetHashCode();
        }

        [Fact]
        public void ToStringが成功する()
        {
            var value = new ChainComparableValue<string>(Any<string>.Value);

            value.ToString();
        }
    }
}
