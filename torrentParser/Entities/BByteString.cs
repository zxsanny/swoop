using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using uHelper.Extensions;

namespace TorrentParser.Entities
{
    public class BByteString : List<byte>, IBObject
    {
        public BByteString(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            var strLengthBytes = new byte[Definitions.MaxIntegerDigits];

            int readByte = 1;
            int countBytesRead = 0;

            while (readByte >= 0)
            {
                readByte = stream.ReadByte();

                if (readByte == Definitions.ASCII_colon)
                    break; // found delimiter between header (length) and contents of the byte string, so start copying
                if (readByte < 0)
                    throw new Exception("Badly formatted byte string, no colon-character found");
                if (countBytesRead >= Definitions.MaxIntegerDigits)
                    throw new Exception("Byte string length is a larger number than what is supported");

                countBytesRead++;
                strLengthBytes[countBytesRead - 1] = (byte)readByte;
            }

            long length = long.Parse(Encoding.ASCII.GetString(strLengthBytes, 0, countBytesRead));

            var byteStringBytes = new byte[length];
            int numberOfBytesRead = stream.Read(byteStringBytes, 0, (int)length);

            if (numberOfBytesRead != length)
                throw new Exception(string.Format("Expected string to be {0} bytes long, could only read {1} bytes", length, numberOfBytesRead));

            AddRange(byteStringBytes);
        }
        public void Encode(Stream stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            // Write byte string "header":
            byte[] strLengthBytes = Encoding.ASCII.GetBytes(Count.ToString());

            stream.Write(strLengthBytes, 0, strLengthBytes.Length);
            stream.WriteByte(Definitions.ASCII_colon);

            stream.Write(this.ToArray(), 0, this.Count);
        }

        private const long maxBytesToUseInHash = 12;
        private const long hashCoeff = 37;
        public override int GetHashCode()
        {
            long hashValue = 0;
            long maxTableSize = UInt32.MaxValue;
            long bytesToHash = Count < 12 ? Count : maxBytesToUseInHash;

            for (int i = 0; i < bytesToHash; i++)
                hashValue = (hashCoeff*hashValue + this[i])%maxTableSize;

            // Transform hash value from UInt32 space to signed Int32 space:
            int returnValue = (int) (hashValue - Int32.MaxValue) - 1;
            return returnValue;
        }
        public override bool Equals(object obj)
        {
            bool equals = false;
            if (obj is BByteString)
            {
                var byteString = obj as BByteString;
                equals = this.IsEqualWith(byteString);
            }
            return equals;
        }

        public string ConvertToText(Encoding encodingToUse)
        {
            return encodingToUse.GetString(this.ToArray(), 0, this.Count);
        }
        public string ASCIIString
        {
            get { return Encoding.ASCII.GetString(this.ToArray(), 0, Count); }
        }
        public string UnicodeString
        {
            get { return Encoding.Unicode.GetString(this.ToArray(), 0, Count); }
        }
        public override string ToString()
        {
            return ASCIIString;
        }
        
        public string Print(int indentLevel = 0)
        {
            return string.Format("{0}{1}{2}",new string(' ',indentLevel),this,Environment.NewLine);
        }

    }
}
