using Xunit;

namespace ChainComparable.Tests
{
    public class CompareResultTest
    {
        [Fact]
        public void boolにキャストしてみる()
        {
            var trueResult = new CompareResult<int>(true, Any<int>.Value);
            var falseResult = new CompareResult<int>(false, Any<int>.Value);

            Assert.True(trueResult);
            Assert.False(falseResult);
        }

        [Fact]
        public void Tにキャストしてみる()
        {
            var result = new CompareResult<int>(Any<bool>.Value, 100);

            Assert.Equal(100, result);
        }

        [Fact]
        public void Negateのテスト()
        {
            var trueResult = new CompareResult<int>(true, Any<int>.Value);
            var falseResult = new CompareResult<int>(false, Any<int>.Value);

            Assert.False(trueResult.Negate());
            Assert.True(falseResult.Negate());
        }

        [Fact]
        public void Equalsのテスト()
        {
            var result = new CompareResult<int>(Any<bool>.Value, 100);

            Assert.False(result.Equals(99));
            Assert.True(result.Equals(100));
            Assert.False(result.Equals(101));
        }
        
        [Fact]
        public void Equals_objectのテスト()
        {
            var result = new CompareResult<int>(Any<bool>.Value, 100);

            Assert.False(result.Equals((object)99));
            Assert.True(result.Equals((object)100));
            Assert.False(result.Equals((object)101));
        }

        [Fact]
        public void Equalsでnullとnull以外を比較すると等しくない()
        {
            var nullResult = new CompareResult<string>(Any<bool>.Value, null);
            var nonNullResult = new CompareResult<string>(Any<bool>.Value, string.Empty);

            Assert.False(nonNullResult.Equals(null));
            Assert.False(nullResult.Equals(string.Empty));
        }
        
        [Fact]
        public void Equals_objectでnullとnull以外を比較すると等しくない()
        {
            var nullResult = new CompareResult<string>(Any<bool>.Value, null);
            var nonNullResult = new CompareResult<string>(Any<bool>.Value, string.Empty);

            Assert.False(nonNullResult.Equals((object)null));
            Assert.False(nullResult.Equals((object)string.Empty));
        }

        [Fact]
        public void Equalsでnull同士を比較すると等しい()
        {
            var result = new CompareResult<string>(Any<bool>.Value, null);

            Assert.True(result.Equals(null));
        }
        
        [Fact]
        public void Equals_objectでnull同士を比較すると等しい()
        {
            var result = new CompareResult<string>(Any<bool>.Value, null);

            Assert.True(result.Equals((object)null));
        }

        [Fact]
        public void CompareToのテスト()
        {
            var result = new CompareResult<int>(Any<bool>.Value, 100);

            Assert.True(result.CompareTo(99) > 0);
            Assert.True(result.CompareTo(100) == 0);
            Assert.True(result.CompareTo(99) > 0);
        }

        [Fact]
        public void CompareToでnullとnull以外の値を比較するとnullは最小値とみなされる()
        {
            var nullResult = new CompareResult<string>(Any<bool>.Value, null);
            var nonNullResult = new CompareResult<string>(Any<bool>.Value, string.Empty);

            Assert.True(nonNullResult.CompareTo(null) > 0);
            Assert.True(nullResult.CompareTo(string.Empty) < 0);
        }

        [Fact]
        public void CompareToでnull同士を比較すると等しい()
        {
            var result = new CompareResult<string>(Any<bool>.Value, null);

            Assert.Equal(0, result.CompareTo(null));
        }

        [Fact]
        public void GetHashCodeが成功する()
        {
            var result = new CompareResult<int>(Any<bool>.Value, Any<int>.Value);

            result.GetHashCode();
        }

        [Fact]
        public void ToStringが成功する()
        {
            var result = new CompareResult<int>(Any<bool>.Value, Any<int>.Value);

            result.ToString();
        }
    }
}
