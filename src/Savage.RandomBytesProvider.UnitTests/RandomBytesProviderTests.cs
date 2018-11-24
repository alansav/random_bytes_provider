using System;
using Xunit;

namespace Savage.Providers
{
    public class RandomBytesProviderTests
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(256)]
        public void GetBytes_returns_an_array_of_bytes_with_the_expected_length(int expectedLength)
        {
            var sut = new RandomBytesProvider();
            var actual = sut.GetBytes(expectedLength);

            Assert.Equal(expectedLength, actual.Length);
        }

        [Fact]
        public void GetBytes_throws_Exception_when_the_length_is_less_than_zero()
        {
            var sut = new RandomBytesProvider();
            Assert.Throws<ArgumentOutOfRangeException>(() => sut.GetBytes(-1));
        }

        [Fact]
        public void GetBytes_returns_unique_values()
        {
            var sut = new RandomBytesProvider();
            var random1 = sut.GetBytes(32);
            var random2 = sut.GetBytes(32);

            Assert.NotEqual(random1, random2);
        }
    }
}
