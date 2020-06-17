using Xunit;

namespace ChainComparable.Tests
{
    public class ChainComparableValueTest
    {
        [Fact]
        public void �񍀏��Ȃ艉�Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

            Assert.True(a < b);
        }

        [Fact]
        public void �񍀑�Ȃ艉�Z()
        {
            var a = new ChainComparableValue<int>(2);
            var b = new ChainComparableValue<int>(1);

            Assert.True(a > b);
        }

        [Fact]
        public void �񍀓��l���Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);

            Assert.True(a == b);
        }

        [Fact]
        public void �񍀔񓙒l���Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

            Assert.True(a != b);
        }

        [Fact]
        public void �񍀏��Ȃ蓙�l���Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);

            Assert.True(a <= b);
        }
        
        [Fact]
        public void �񍀑�Ȃ蓙�l���Z()
        {
            var a = new ChainComparableValue<int>(2);
            var b = new ChainComparableValue<int>(1);

            Assert.True(a >= b);
        }

        [Fact]
        public void �O�����Ȃ艉�Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a < b < c);
        }

        [Fact]
        public void �O����Ȃ艉�Z()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a > b > c);
        }

        [Fact]
        public void �O�����l���Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a == b == c);
        }
        
        [Fact]
        public void �O�����l_�s���l���Z()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(2);

            Assert.True(a == b != c);
        }

        [Fact]
        public void �O�����Ȃ艉�Z�J�b�R��()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(3);

            Assert.True(a < (b < c));
        }
        
        [Fact]
        public void �O����Ȃ艉�Z�J�b�R��()
        {
            var a = new ChainComparableValue<int>(3);
            var b = new ChainComparableValue<int>(2);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a > (b > c));
        }
                
        [Fact]
        public void �O�����l���Z�J�b�R��()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);

            Assert.True(a == (b == c));
        }
                        
        [Fact]
        public void �l�����l���Z�J�b�R��()
        {
            var a = new ChainComparableValue<int>(1);
            var b = new ChainComparableValue<int>(1);
            var c = new ChainComparableValue<int>(1);
            var d = new ChainComparableValue<int>(1);

            Assert.True((a == b) == (c == d));
        }
    }
}
