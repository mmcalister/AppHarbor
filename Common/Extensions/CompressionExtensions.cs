using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace Common.Extensions
{
    /// <summary>
    /// Methods for compressing/decompressing an array of bytes
    /// </summary>
    /// <!-- @author Matt -->
    public static class CompressionExtensions
    {
        /// <summary>
        /// Compresses the specified bytes.
        /// </summary>
        /// <param name="bytes">Array of bytes to compress.</param>
        /// <returns>An array of compressed bytes.</returns>
        /// <!-- @author Matt -->
        public static byte[] Compress(this byte[] bytes)
        {
            MemoryStream stream;
            using (var writer = new BinaryWriter(new GZipStream(stream = new MemoryStream(), CompressionMode.Compress)))
            {
                writer.Write(bytes);
            }
            return stream.ToArray();
        }

        /// <summary>
        /// Decompresses the specified bytes.
        /// </summary>
        /// <param name="bytes">Array of bytes to decompress.</param>
        /// <returns>An array of decompressed bytes.</returns>
        /// <!-- @author Matt -->
        public static byte[] Decompress(this byte[] bytes)
        {
            return bytes._Decompress().ToArray();
        }

        private static IEnumerable<byte> _Decompress(this byte[] bytes)
        {
            using (var reader = new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress))
            {
                const int bufferSize = 1024;
                byte[] buffer = new byte[bufferSize];
                int bytesRead;
                do
                {
                    bytesRead = reader.Read(buffer, 0, bufferSize);
                    for (int i = 0; i < bytesRead; i++)
                        yield return buffer[i];
                }
                while (bytesRead == bufferSize);
            }
        }
    }
}
