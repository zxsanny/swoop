using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TorrentParser.Entities
{
    public class BList : List<IBObject>, IBObject
    {
        public BList(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");
            if (stream.ReadByte() != Definitions.ASCII_l)
                throw new Exception("List did not start with correct character at position " + stream.Position);

            var nextObject = stream.CreateBObject();
            while (nextObject != null)
            {
                Add(nextObject);
                nextObject = stream.CreateBObject();
            }
        }
        public void Encode(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            stream.WriteByte(Definitions.ASCII_l);

            foreach (var item in this)
                item.Encode(stream);

            stream.WriteByte(Definitions.ASCII_e);
        }

        public override string ToString()
        {
            return "L:" + string.Join(",_", this) + ":L";
        }
        
        public string Print(int indentLevel = 0)
        {
            var sb = new StringBuilder();
            foreach (var elem in this)
                sb.Append("{").Append(elem.Print(indentLevel + 1)).Append("}");
            return sb.ToString();
        }
    }
}
