using System.Collections.Generic;
using Swoop.Common.Models;

namespace Swoop.Common.Repositories
{
    public interface ISeedsRepository
    {
        bool IsSeedExists(int id);
        void AddSeed(Seed seed);

        List<Seed> Find(string filter = "", IList<string> categories = null, SortInfo sortInfo = null);
        List<TrackerSeedsCountInfo> GetCounts();
        List<string> GetCategories(string filter = "");
    }
}