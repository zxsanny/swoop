using System.IO;
using RutrackerManager.TorrentParser.Entities;

namespace TorrentParser.Entities
{
    public interface IBObject
    {
        void Encode(Stream stream);
        string Print(int indentLevel = 0);
    }

    public static class BObjectFactory
    {
        public static IBObject CreateBObject(this Stream stream)
        {
            int b = stream.ReadByte();
            stream.Seek(-1, SeekOrigin.Current);

            if (b == Definitions.ASCII_i)
                return new BInteger(stream);
                
            if (b == Definitions.ASCII_l)
                return new BList(stream);
                
            if (b == Definitions.ASCII_d)
                return new BDictionary(stream);
                
            if (b >= Definitions.ASCII_0 && b <= Definitions.ASCII_9)
                return new BByteString(stream);
                
            //if (stream.ReadByte() != Definitions.ASCII_e)
            //    throw new Exception("Stream has no end of List/Dictionary!");

            if (b == Definitions.ASCII_e)
            {
                // End of list/dictionary
                stream.ReadByte(); // Skip end marker
                return null;
            }

            return null;
        }
    }
}
