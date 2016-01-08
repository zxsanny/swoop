namespace Swoop.Common.Models
{
    public class TrackerInfo
    {
        public string TrackerName { get; set; }
        public string SeedTemplate { get; set; }
        public string MagnetTrackers { get; set; }
        public int Checkpoint { get; set; }

        /// <summary>
        /// Provide basic tracker info
        /// </summary>
        /// <param name="trackerName">Name of tracker, for example 'Rutracker' or 'Rutor'</param>
        /// <param name="seedTemplate">Seed page template, for example 'http://rutracker.org/forum/viewtopic.php?t=' or 'http://rutor.org/torrent/'</param>
        /// <param name="magnetTrackers">Magnet trackers in magnet link, for example 'http://bt.rutracker.cc/ann?magnet'</param>
        public TrackerInfo(string trackerName, string seedTemplate, string magnetTrackers)
        {
            TrackerName = trackerName;
            SeedTemplate = seedTemplate;
            MagnetTrackers = magnetTrackers;
            Checkpoint = 1;
        }

        /// <summary>
        /// Returns template + checkpoint
        /// </summary>
        /// <param name="checkpoint"></param>
        /// <returns></returns>
        public string Url(int checkpoint)
        {
            return SeedTemplate + checkpoint;
        }
    }
}