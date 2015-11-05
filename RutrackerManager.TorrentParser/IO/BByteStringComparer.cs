using System.Collections.Generic;
using RutrackerManager.Common;
using RutrackerManager.TorrentParser.Entities;

namespace RutrackerManager.TorrentParser.IO
{
    class BByteStringComparer : IComparer<BByteString>
    {
        public int Compare(BByteString x, BByteString y)
        {
            return x.RawCompare(y);
        }
    }
}
