using Xunit;

namespace ChainComparable.Tests
{
    public class CompareResultTest
    {
        [Fact]
        public void boolにキャストしてみる()
        {
            var trueResult = new CompareResult<int>(true, default);
            var falseResult = new CompareResult<int>(false, default);

            Assert.True(trueResult);
            Assert.False(falseResult);
        }

        [Fact]
        public void Tにキャストしてみる()
        {
            var result = new CompareResult<int>(default, 100);

            Assert.Equal(100, result);
        }

        [Fact]
        public void Negateのテスト()
        {
            var trueResult = new CompareResult<int>(true, default);
            var falseResult = new CompareResult<int>(false, default);

            Assert.False(trueResult.Negate());
            Assert.True(falseResult.Negate());
        }

        [Fact]
        public void Equalsのテスト()
        {
            var result = new CompareResult<int>(default, 100);

            Assert.False(result.Equals(99));
            Assert.True(result.Equals(100));
            Assert.False(result.Equals(101));
        }

        [Fact]
        public void Equalsでnullとnull以外を比較すると等しくない()
        {
            var nullResult = new CompareResult<string>(default, null);
            var nonNullResult = new CompareResult<string>(default, string.Empty);

            Assert.False(nonNullResult.Equals(null));
            Assert.False(nullResult.Equals(string.Empty));
        }
        
        [Fact]
        public void Equalsでnull同士を比較すると等しい()
        {
            var result = new CompareResult<string>(default, null);

            Assert.True(result.Equals(null));
        }

        [Fact]
        public void CompareToのテスト()
        {
            var result = new CompareResult<int>(default, 100);

            Assert.True(result.CompareTo(99) > 0);
            Assert.True(result.CompareTo(100) == 0);
            Assert.True(result.CompareTo(99) > 0);
        }

        [Fact]
        public void CompareToでnullとnull以外の値を比較するとnullは最小値とみなされる()
        {
            var nullResult = new CompareResult<string>(default, null);
            var nonNullResult = new CompareResult<string>(default, string.Empty);

            Assert.True(nonNullResult.CompareTo(null) > 0);
            Assert.True(nullResult.CompareTo(string.Empty) < 0);
        }

        [Fact]
        public void CompareToでnull同士を比較すると等しい()
        {
            var result = new CompareResult<string>(default, null);

            Assert.Equal(0, result.CompareTo(null));
        }
    }
}
