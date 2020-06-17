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
    }
}
