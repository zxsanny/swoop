namespace Swoop.Common.Models
{
    public class TrackerSeedsCountInfo
    {
        public string TrackerName { get; set; }
        public int Count { get; set; }

        public TrackerSeedsCountInfo(string trackerName, int count)
        {
            TrackerName = trackerName;
            Count = count;
        }
    }
}
