using System;

using Xunit;

namespace ChainComparable.Tests
{
    public class ChainComparerTest
    {
        [Fact]
        public void DefaultEqualityComparerはnullじゃない()
        {
            Assert.NotNull(ChainComparer<int>.DefaultEqualityComparer);
        }

        [Fact]
        public void DefaultComparerはnullじゃない()
        {
            Assert.NotNull(ChainComparer<int>.DefaultComparer);
        }

        [Fact]
        public void EqualityComparerの既定値はnullじゃない()
        {
            Assert.NotNull(ChainComparer<int>.EqualityComparer);
        }

        [Fact]
        public void Comparerの既定値はnullじゃない()
        {
            Assert.NotNull(ChainComparer<int>.Comparer);
        }

        [Fact]
        public void EqualityComparerにnullをセットするとArgumentNullExceptionが飛ぶ()
        {
            Assert.Throws<ArgumentNullException>(
                () => {
                    ChainComparer<int>.EqualityComparer = null!;
                });
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
