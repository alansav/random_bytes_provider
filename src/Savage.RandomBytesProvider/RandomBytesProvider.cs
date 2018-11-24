using System;
using System.Security.Cryptography;

namespace Savage.Providers
{
    public interface IRandomBytesProvider
    {
        byte[] GetBytes(int length);
    }

    public class RandomBytesProvider : IRandomBytesProvider
    {
        public byte[] GetBytes(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "GetBytes must be given a value greater or equal to 1.");
            }

            var bytes = new byte[length];

            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return bytes;
        }
    }
}
