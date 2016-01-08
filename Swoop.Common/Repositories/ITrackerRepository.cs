using System.Collections.Generic;
using Swoop.Common.Models;

namespace Swoop.Common.Repositories
{
    public interface ITrackerRepository
    {
        List<TrackerInfo> GetAll();
        TrackerInfo GetTrackerInfo(string trackerName);

        void SaveCheckPoint(TrackerInfo info);
        void SaveCheckPoint(string trackerName, int checkpoint);
        void Save(TrackerInfo info);
    }
}
