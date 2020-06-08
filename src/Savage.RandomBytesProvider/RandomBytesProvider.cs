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
        /// <summary>
        /// Returns an array of bytes with a cryptographically strong random sequence of values.
        /// </summary>
        /// <param name="length">The size of the array to return</param>
        /// <returns>An array of bytes of the specified length containing cryptographically strong random sequence of values</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the value for length is less than 1.</exception>
        public byte[] GetBytes(int length)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "GetBytes must be given a value greater or equal to 1.");
            }

            var bytes = new byte[length];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(bytes);
            }
            return bytes;
        }
    }
}
