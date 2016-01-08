using System.Text;
using Noemax.Compression;

namespace Swoop.Compressor
{
    public class NoemaxCompressor : ICompressor
    {
        private CompressionFactory CompressionFactory { get; set; }
        private int Level { get; set; }

        public NoemaxCompressor()
        {
            CompressionFactory = CompressionFactory.Deflate;
            Level = 9;
        }

        public byte[] Compress(string text)
        {
            return CompressionFactory.Compress(Encoding.UTF8.GetBytes(text), Level);
        }

        public string Decompress(byte[] bytes)
        {
            return Encoding.UTF8.GetString(CompressionFactory.Decompress(bytes));
        }
    }
}
