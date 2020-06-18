using System;

using Xunit;

namespace ChainComparable.Tests
{
    public class ChainComparerTest
    {
        [Fact]
        public void DefaultComparerはnullじゃない()
        {
            Assert.NotNull(ChainComparer<int>.DefaultComparer);
        }

        [Fact]
        public void Comparerの既定値はnullじゃない()
        {
            Assert.NotNull(ChainComparer<int>.Comparer);
        }

        [Fact]
        public void ComparerにnullをセットするとArgumentNullExceptionが飛ぶ()
        {
            Assert.Throws<ArgumentNullException>(
                () => {
                    ChainComparer<int>.Comparer = null!;
                });
        }
    }
}
