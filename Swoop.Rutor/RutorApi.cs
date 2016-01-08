using System;
using log4net;
using Swoop.Common;
using Swoop.Common.Models;

namespace Swoop.RutorApi
{
    public class RutorApi : BaseTrackerApi
    {
        public RutorApi(ILog logger) : base(logger)
        {}

        public override TrackerInfo TrackerInfo
        {
            get { return new TrackerInfo("Rutor", "http://rutor.org/torrent/", "udp://opentor.org:2710&tr=udp://bt.rutor.org:2710&tr=http://retracker.local/announce"); }
        }

        public override Seed GetSeed(int id)
        {
            var page = GetPageContent(id);

            //return new Seed(TrackerInfo, id, );
            throw new NotImplementedException();
        }
    }
}
