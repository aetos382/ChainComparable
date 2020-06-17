using Xunit;

namespace ChainComparable.Tests
{
    public class ComparerTest
    {
        [Fact]
        public void 同じ値の場合は0()
        {
            int result = Comparer.SafeCompare(100, 100);

            Assert.Equal(0, result);
        }

        [Fact]
        public void 左が大きい場合は正の値()
        {
            int result = Comparer.SafeCompare(100, 99);

            Assert.True(result > 0);
        }

        [Fact]
        public void 左が小さい場合は負の値()
        {
            int result = Comparer.SafeCompare(99, 100);

            Assert.True(result < 0);
        }

        [Fact]
        public void 左がnullの場合は負の値()
        {
            int result = Comparer.SafeCompare(null, "100");

            Assert.True(result < 0);
        }

        [Fact]
        public void 右がnullの場合は正の値()
        {
            int result = Comparer.SafeCompare("100", null);

            Assert.True(result > 0);
        }

        [Fact]
        public void 両方ともnullの場合は0()
        {
            int result = Comparer.SafeCompare((string)null, null);

            Assert.Equal(0, result);
        }
    }
}
