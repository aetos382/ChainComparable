using Xunit;

namespace ChainComparable.Tests
{
    public class MyIntTest
    {
        [Fact]
        public void 二項小なり演算()
        {
            var a = new MyInt(1);
            var b = new MyInt(2);

            Assert.True(a < b);
        }

        [Fact]
        public void 二項大なり演算()
        {
            var a = new MyInt(2);
            var b = new MyInt(1);

            Assert.True(a > b);
        }

        [Fact]
        public void 二項等値演算()
        {
            var a = new MyInt(1);
            var b = new MyInt(1);

            Assert.True(a == b);
        }

        [Fact]
        public void 二項非等値演算()
        {
            var a = new MyInt(1);
            var b = new MyInt(2);

            Assert.True(a != b);
        }

        [Fact]
        public void 二項小なり等値演算()
        {
            var a = new MyInt(1);
            var b = new MyInt(2);

            Assert.True(a <= b);
        }
        
        [Fact]
        public void 二項大なり等値演算()
        {
            var a = new MyInt(2);
            var b = new MyInt(1);

            Assert.True(a >= b);
        }

        [Fact]
        public void 三項小なり演算()
        {
            var a = new MyInt(1);
            var b = new MyInt(2);
            var c = new MyInt(3);

            Assert.True(a < b < c);
        }

        [Fact]
        public void 三項大なり演算()
        {
            var a = new MyInt(3);
            var b = new MyInt(2);
            var c = new MyInt(1);

            Assert.True(a > b > c);
        }

        [Fact]
        public void 三項等値演算()
        {
            var a = new MyInt(1);
            var b = new MyInt(1);
            var c = new MyInt(1);

            Assert.True(a == b == c);
        }

        [Fact]
        public void 三項小なり演算カッコつき()
        {
            var a = new MyInt(1);
            var b = new MyInt(2);
            var c = new MyInt(3);

            Assert.True(a < (b < c));
        }
        
        [Fact]
        public void 三項大なり演算カッコつき()
        {
            var a = new MyInt(3);
            var b = new MyInt(2);
            var c = new MyInt(1);

            Assert.True(a > (b > c));
        }
                
        [Fact]
        public void 三項等値演算カッコつき()
        {
            var a = new MyInt(1);
            var b = new MyInt(1);
            var c = new MyInt(1);

            Assert.True(a == (b == c));
        }
                        
        [Fact]
        public void 四項等値演算カッコつき()
        {
            var a = new MyInt(1);
            var b = new MyInt(1);
            var c = new MyInt(1);
            var d = new MyInt(1);

            Assert.True((a == b) == (c == d));
        }
    }
}
