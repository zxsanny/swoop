using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TorrentParser.IO;

namespace TorrentParser.Entities
{
    public class BDictionary : Dictionary<BByteString, IBObject>, IBObject
    {
        public BDictionary(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            if (stream.ReadByte() != Definitions.ASCII_d)
                throw new Exception("Dictionary did not start with correct character at position " + stream.Position);

            IBObject nextKey, nextValue;

            do
            {
                nextKey = stream.CreateBObject();
                nextValue = stream.CreateBObject();
                
                if (nextKey == null)
                    break;
                if (!(nextKey is BByteString))
                    throw new Exception(string.Format("Illegal type {0} detected for BDictionary key at position {1}", nextKey.GetType().Name, stream.Position));

                Add((BByteString) nextKey, nextValue);
            } while (nextValue != null);
        }
        public void Encode(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            stream.WriteByte(Definitions.ASCII_d);

            var sortedKVPairs = this.OrderBy( kvPair => kvPair.Key, new BByteStringComparer());
            foreach (var kwPair in sortedKVPairs)
            {
                kwPair.Key.Encode(stream);
                kwPair.Value.Encode(stream);
            }
            stream.WriteByte(Definitions.ASCII_e);
        }

        public override string ToString()
        {
            return "D:" + string.Join(";_", this) + ":D";
        }
        
        public string Print(int indentLevel = 0)
        {
            var sb = new StringBuilder();
            sb.Append("D:");
            foreach (var kvp in this)
                sb.Append(kvp.Key).Append(":").Append(kvp.Value.Print(indentLevel + 1));
            sb.Append(":D");
            return sb.ToString();
        }
    }
}
