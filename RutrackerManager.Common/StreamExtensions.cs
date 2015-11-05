using System.IO;

namespace RutrackerManager.Common
{
    public static class StreamExtensions
    {
        public static void ToFile(this Stream stream, string filename)
        {
            var fileStream = File.Create(filename);
            //stream.Seek(0, SeekOrigin.Begin);
            stream.CopyTo(fileStream);
            fileStream.Close();
        }
    }
}
