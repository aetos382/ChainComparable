#pragma warning disable CA1707

using Xunit;

namespace ChainComparable.Tests
{
    public class CompareResultTest
    {
        [Fact]
        // ReSharper disable once InconsistentNaming
        public void boolにキャストしてみる()
        {
            var trueResult = new CompareResult<int>(true, Any<int>.Value, Any<int>.Value);
            var falseResult = new CompareResult<int>(false, Any<int>.Value, Any<int>.Value);

            Assert.True(trueResult);
            Assert.False(falseResult);
        }

        [Fact]
        public void Negateのテスト()
        {
            var trueResult = new CompareResult<int>(true, Any<int>.Value, Any<int>.Value);
            var falseResult = new CompareResult<int>(false, Any<int>.Value, Any<int>.Value);

            Assert.False(trueResult.Negate());
            Assert.True(falseResult.Negate());
        }

        [Fact]
        public void 等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2);
            var right = new CompareResult<int>(Any<bool>.Value, 2, 3);

            // 2 == 2
            Assert.True(left == right);
        }

        [Fact]
        public void 等値比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 1, 2);

            // 1 == 1
            Assert.True(left == right);
        }

        [Fact]
        public void 等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2);
            var right = 2;

            // 2 == 2
            Assert.True(left == right);
        }

        [Fact]
        public void 非等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2);
            var right = new CompareResult<int>(Any<bool>.Value, 1, 2);

            // 2 != 1
            Assert.True(left != right);
        }

        [Fact]
        public void 非等値比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 2, 1);

            // 1 != 2
            Assert.True(left != right);
        }

        [Fact]
        public void 非等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2);
            var right = 1;

            // 2 != 1
            Assert.True(left != right);
        }

        [Fact]
        public void 小なり比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 1);
            var right = new CompareResult<int>(Any<bool>.Value, 200, 1);

            // 1 < 200
            Assert.True(left < right);
        }

        [Fact]
        public void 小なり比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 2, 100);

            // 1 < 2
            Assert.True(left < right);
        }

        [Fact]
        public void 小なり比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 1);
            var right = 2;

            // 1 < 2
            Assert.True(left < right);
        }

        [Fact]
        public void 大なり比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 2);
            var right = new CompareResult<int>(Any<bool>.Value, 1, 100);

            // 2 > 1
            Assert.True(left > right);
        }

        [Fact]
        public void 大なり比較_左がT()
        {
            var left = 2;
            var right = new CompareResult<int>(Any<bool>.Value, 1, 100);

            // 2 > 1
            Assert.True(left > right);
        }

        [Fact]
        public void 大なり比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 2);
            var right = 1;

            // 2 > 1
            Assert.True(left > right);
        }

        [Fact]
        public void 小なり等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 1);
            var right = new CompareResult<int>(Any<bool>.Value, 200, 1);

            // 1 < 200
            Assert.True(left <= right);
        }

        [Fact]
        public void 小なり等値比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 2, 100);

            // 1 < 2
            Assert.True(left <= right);
        }

        [Fact]
        public void 小なり等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 1);
            var right = 2;

            // 1 < 2
            Assert.True(left <= right);
        }

        [Fact]
        public void 大なり等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 2);
            var right = new CompareResult<int>(Any<bool>.Value, 1, 100);

            // 2 > 1
            Assert.True(left >= right);
        }

        [Fact]
        public void 大なり等値比較_左がT()
        {
            var left = 2;
            var right = new CompareResult<int>(Any<bool>.Value, 1, 100);

            // 2 > 1
            Assert.True(left >= right);
        }

        [Fact]
        public void 大なり等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 100, 2);
            var right = 1;

            // 2 > 1
            Assert.True(left >= right);
        }
    }
}
