using Xunit;

namespace ChainComparable.Tests
{
    public class ChainComparableValueTest
    {
        [Fact]
        public void 二項小なり演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

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
        public void 二項等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);

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
        public void 二項小なり等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

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
        public void 三項小なり演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a < b < c);
        }

        [Fact]
        public void 三項大なり演算()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a > b > c);
        }

        [Fact]
        public void 三項等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a == b == c);
        }
        
        [Fact]
        public void 三項等値_不等値演算()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(2);

            Assert.True(a == b != c);
        }

        [Fact]
        public void 三項小なり演算カッコつき()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a < (b < c));
        }
        
        [Fact]
        public void 三項大なり演算カッコつき()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a > (b > c));
        }
                
        [Fact]
        public void 三項等値演算カッコつき()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a == (b == c));
        }
        
        [Fact]
        public void 四項等値演算カッコつき()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);
            var d = new ChainComparableValue<int>(1);

            Assert.True(a == b == (c == d));
        }

        [Fact]
        public void Tにキャストしてみる()
        {
            var result = new ChainComparableValue<int>(100);

            Assert.Equal(100, result);
        }

        [Fact]
        public void Equalsのテスト()
        {
            var result = new ChainComparableValue<int>(100);

            Assert.False(result.Equals(99));
            Assert.True(result.Equals(100));
            Assert.False(result.Equals(101));
        }
        
        [Fact]
        public void Equals_objectのテスト()
        {
            var result = new ChainComparableValue<int>(100);

            Assert.False(result.Equals((object)99));
            Assert.True(result.Equals((object)100));
            Assert.False(result.Equals((object)101));
        }

        [Fact]
        public void Equalsでnullとnull以外を比較すると等しくない()
        {
            var nullResult = new ChainComparableValue<string>(null);
            var nonNullResult = new ChainComparableValue<string>(string.Empty);

            Assert.False(nonNullResult.Equals(null));
            Assert.False(nullResult.Equals(string.Empty));
        }
        
        [Fact]
        public void Equals_objectでnullとnull以外を比較すると等しくない()
        {
            var nullResult = new ChainComparableValue<string>(null);
            var nonNullResult = new ChainComparableValue<string>(string.Empty);

            Assert.False(nonNullResult.Equals((object)null));
            Assert.False(nullResult.Equals((object)string.Empty));
        }

        [Fact]
        public void Equalsでnull同士を比較すると等しい()
        {
            var result = new ChainComparableValue<string>(null);

            Assert.True(result.Equals(null));
        }
        
        [Fact]
        public void Equals_objectでnull同士を比較すると等しい()
        {
            var result = new ChainComparableValue<string>(null);

            Assert.True(result.Equals((object)null));
        }

        [Fact]
        public void CompareToのテスト()
        {
            var result = new ChainComparableValue<int>(100);

            Assert.True(result.CompareTo(99) > 0);
            Assert.True(result.CompareTo(100) == 0);
            Assert.True(result.CompareTo(99) > 0);
        }

        [Fact]
        public void CompareToでnullとnull以外の値を比較するとnullは最小値とみなされる()
        {
            var nullResult = new ChainComparableValue<string>(null);
            var nonNullResult = new ChainComparableValue<string>(string.Empty);

            Assert.True(nonNullResult.CompareTo(null) > 0);
            Assert.True(nullResult.CompareTo(string.Empty) < 0);
        }

        [Fact]
        public void CompareToでnull同士を比較すると等しい()
        {
            var result = new ChainComparableValue<string>(null);

            Assert.Equal(0, result.CompareTo(null));
        }
    }
}
