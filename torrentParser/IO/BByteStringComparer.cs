using System.Collections.Generic;
using TorrentParser.Entities;
using uHelper.Extensions;

namespace TorrentParser.IO
{
    class BByteStringComparer : IComparer<BByteString>
    {
        public int Compare(BByteString x, BByteString y)
        {
            return x.RawCompare(y);
        }
    }
}
