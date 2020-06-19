#pragma warning disable CA1707

using Xunit;

namespace ChainComparable.Tests
{
    public class CompareResultTest
    {
        [Fact]
        public void 初期化()
        {
            var result = new CompareResult<int>(true, 1, 2, ComparisonOperator.Equality);

            Assert.True(result.Result);
            Assert.Equal(1, result.LeftValue);
            Assert.Equal(2, result.RightValue);
            Assert.Equal(ComparisonOperator.Equality, result.Operator);
        }

        [Fact]
        // ReSharper disable once InconsistentNaming
        public void boolにキャストしてみる()
        {
            var trueResult = new CompareResult<int>(true, Any<int>.Value, Any<int>.Value, ComparisonOperator.Equality);
            var falseResult = new CompareResult<int>(false, Any<int>.Value, Any<int>.Value, ComparisonOperator.Equality);

            Assert.True(trueResult);
            Assert.False(falseResult);
        }

        [Fact]
        public void NegateするとResultが反転すること()
        {
            var trueResult = new CompareResult<int>(true, Any<int>.Value, Any<int>.Value, ComparisonOperator.Equality);

            Assert.True(trueResult.Result);

            var negatedResult = trueResult.Negate();

            Assert.False(negatedResult.Result);

            var negatedResult2 = negatedResult.Negate();

            Assert.True(negatedResult2.Result);
        }

        [Theory]
        [InlineData(ComparisonOperator.Equality, ComparisonOperator.Inequality)]
        [InlineData(ComparisonOperator.Inequality, ComparisonOperator.Equality)]
        [InlineData(ComparisonOperator.LessThan, ComparisonOperator.GreaterThanOrEqual)]
        [InlineData(ComparisonOperator.GreaterThan, ComparisonOperator.LessThanOrEqual)]
        [InlineData(ComparisonOperator.LessThanOrEqual, ComparisonOperator.GreaterThan)]
        [InlineData(ComparisonOperator.GreaterThanOrEqual, ComparisonOperator.LessThan)]
        public void NegateするとOperatorが反転すること(
            ComparisonOperator original,
            ComparisonOperator negated)
        {
            var trueResult = new CompareResult<int>(
                Any<bool>.Value,
                Any<int>.Value,
                Any<int>.Value,
                original);

            var negatedResult = trueResult.Negate();

            Assert.Equal(negated, negatedResult.Operator);
        }

        [Fact]
        public void NegateしてもLeftValueとRightValueは変わらないこと()
        {
            var result = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);

            Assert.Equal(1, result.LeftValue);
            Assert.Equal(2, result.RightValue);

            var negatedResult = result.Negate();

            Assert.Equal(1, negatedResult.LeftValue);
            Assert.Equal(2, negatedResult.RightValue);
        }

        [Fact]
        public void 等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);
            var right = new CompareResult<int>(Any<bool>.Value, 2, 3, ComparisonOperator.Equality);

            // 2 == 2
            Assert.True(left == right);
        }

        [Fact]
        public void 等値比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);

            // 1 == 1
            Assert.True(left == right);
        }

        [Fact]
        public void 等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);
            var right = 2;

            // 2 == 2
            Assert.True(left == right);
        }

        [Fact]
        public void 非等値比較()
        {
            // left.LeftValue、left.RightValue、right.LeftValue、right.RightValue で
            // 2x2 = 4 通りの比較の組み合わせがありうる。
            // left.RightValue と right.LeftValue を比較していることを確認するためには
            // 2 回の確認が必要だよね。

            var left1 = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);
            var right1 = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);

            // 2 != 1
            Assert.True(left1 != right1);

            var left2 = new CompareResult<int>(Any<bool>.Value, 2, 2, ComparisonOperator.Equality);
            var right2 = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);

            // 2 != 1
            Assert.True(left2 != right2);
        }

        [Fact]
        public void 非等値比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 2, 1, ComparisonOperator.Equality);

            // 1 != 2
            Assert.True(left != right);
        }

        [Fact]
        public void 非等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);
            var right = 1;

            // 2 != 1
            Assert.True(left != right);
        }

        [Fact]
        public void 小なり比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 2, 1, ComparisonOperator.Equality);
            var right = new CompareResult<int>(Any<bool>.Value, 2, 1, ComparisonOperator.Equality);

            // 1 < 2
            Assert.True(left < right);
        }

        [Fact]
        public void 小なり比較_左がT()
        {
            var left = 1;
            var right = new CompareResult<int>(Any<bool>.Value, 2, 1, ComparisonOperator.Equality);

            // 1 < 2
            Assert.True(left < right);
        }

        [Fact]
        public void 小なり比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 2, 1, ComparisonOperator.Equality);
            var right = 2;

            // 1 < 2
            Assert.True(left < right);
        }

        [Fact]
        public void 大なり比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);
            var right = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);

            // 2 > 1
            Assert.True(left > right);
        }

        [Fact]
        public void 大なり比較_左がT()
        {
            var left = 2;
            var right = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);

            // 2 > 1
            Assert.True(left > right);
        }

        [Fact]
        public void 大なり比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 2, ComparisonOperator.Equality);
            var right = 1;

            // 2 > 1
            Assert.True(left > right);
        }

        [Fact]
        public void 小なり等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 4, 2, ComparisonOperator.Equality);
            var right = new CompareResult<int>(Any<bool>.Value, 3, 1, ComparisonOperator.Equality);

            // 2 <= 3
            Assert.True(left <= right);
        }

        [Fact]
        public void 小なり等値比較_左がT()
        {
            var left = 2;
            var right = new CompareResult<int>(Any<bool>.Value, 3, 1, ComparisonOperator.Equality);

            // 2 <= 3
            Assert.True(left <= right);
        }

        [Fact]
        public void 小なり等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 3, 1, ComparisonOperator.Equality);
            var right = 2;

            // 1 <= 2
            Assert.True(left <= right);
        }

        [Fact]
        public void 大なり等値比較()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 3, ComparisonOperator.Equality);
            var right = new CompareResult<int>(Any<bool>.Value, 2, 4, ComparisonOperator.Equality);

            // 3 >= 2
            Assert.True(left >= right);
        }

        [Fact]
        public void 大なり等値比較_左がT()
        {
            var left = 2;
            var right = new CompareResult<int>(Any<bool>.Value, 1, 3, ComparisonOperator.Equality);

            // 2 >= 1
            Assert.True(left >= right);
        }

        [Fact]
        public void 大なり等値比較_右がT()
        {
            var left = new CompareResult<int>(Any<bool>.Value, 1, 3, ComparisonOperator.Equality);
            var right = 2;

            // 2 >= 1
            Assert.True(left >= right);
        }

        [Fact]
        public void ToStringが成功する()
        {
            var result = new CompareResult<int>(true, 1, 2, ComparisonOperator.Equality);

            _ = result.ToString();
        }
    }
}
