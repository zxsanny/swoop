namespace Swoop.Compressor
{
    public interface ICompressor
    {
        byte[] Compress(string text);
        string Decompress(byte[] bytes);
    }
}
