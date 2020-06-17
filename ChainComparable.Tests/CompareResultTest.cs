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
    }
}
