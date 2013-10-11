using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace TorrentParser.Entities
{
    public sealed class BInteger : IBObject
    {
        private long Value { get; set; }

        public BInteger(Stream stream)
        {
            var characters = new byte[Definitions.MaxIntegerDigits];
            int characterCount = 0;

            stream.ReadByte();                             // skip 'i'

            int readByte = stream.ReadByte();

            while (readByte > 0 && readByte != Definitions.ASCII_e && characterCount <= Definitions.MaxIntegerDigits)
            {
                // Validation: only allow minus or digit as byte zero and otherwise only digits:
                if ((readByte == Definitions.ASCII_minus && characterCount == 0) ||
                    (readByte >= Definitions.ASCII_0 && readByte <= Definitions.ASCII_9))
                {
                    characters[characterCount] = (byte) readByte;
                    characterCount++;
                    readByte = stream.ReadByte();
                }
                else
                    throw new Exception(string.Format("Byte {0}  of Integer is invalid, at position {1}", characterCount, stream.Position));
            }

            // Validate the input:
            if ((characterCount < 1) ||                         // no characters
                    (readByte != Definitions.ASCII_e) ||            // OR did not end in 'e'
                    (characterCount >= 2 && characters[0] == Definitions.ASCII_minus && characters[1] == Definitions.ASCII_0))      // OR "-0" detected
                throw new Exception("Malformed Integer at position " + stream.Position);
            
            Value = long.Parse(Encoding.ASCII.GetString(characters, 0, characterCount));
        }
        public void Encode(Stream stream)
        {
            stream.WriteByte(Definitions.ASCII_i);

            var bytes = Encoding.ASCII.GetBytes(Value.ToString());
            stream.Write(bytes, 0, bytes.Length);

            stream.WriteByte(Definitions.ASCII_e);
        }

        public override string ToString()
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public string Print(int indentLevel = 0)
        {
            return string.Format("{0}{1}", new string(' ', indentLevel), this);
        }

    }
}
