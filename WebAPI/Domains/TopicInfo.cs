namespace uHelper.webAPI.Domains
{
    public class TopicInfo
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public TopicStatus Status { get; set; }
        public string TorrentLink { get; set; }
        
        public string SizeTGMKB { get; set; }
        public long Size { get; set; }
        
        public string Uploader { get; set; }
        public string Forum { get; set; }

        public int SeedsCount { get; set; }
        public int LeechesCount { get; set; }
        public int DownloadsCount { get; set; }
    
        public TopicInfo()
        {
            Status = TopicStatus.Unknown;
        }
    }
}
