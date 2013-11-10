using System.Linq;
using NSubstitute;
using NUnit.Framework;
using Newtonsoft.Json;
using uHelper.Extensions;
using uHelper.webAPI.Domains;
using uHelper.webAPI.Rutracker;

namespace uHelper.webAPI.Tests
{
    [TestFixture]
    public class RutrackerInfoProviderTest
    {
        private ITrackerInfoProvider RutrackerInfoProvider;
        private ISettingsProvider SettingsProvider;

        [SetUp]
        public void Setup()
        {
            SettingsProvider = Substitute.For<ISettingsProvider>();
            SettingsProvider.Username.Returns("some");
            SettingsProvider.Password.Returns("somePassword");

            RutrackerInfoProvider = new RutrackerInfoProvider(SettingsProvider);
        }

        [Test]
        public void GetTopicInfo_Test()
        {
            const string url = "http://rutracker.org/forum/viewtopic.php?t=2339869";
            
            var topic = RutrackerInfoProvider.GetTopicInfo(url);

            Assert.AreEqual(topic.Url, url);
            Assert.AreEqual(topic.Name, "Зелёная миля / The Green Mile (Фрэнк Дарабонт / Frank Darabont) [1080p] [1999 г., Драма, BDRip]");
            Assert.AreEqual(topic.TorrentLink, "http://dl.rutracker.org/forum/dl.php?t=2339869");
            
            Assert.AreEqual(topic.SizeTGMKB, "18.57 GB");
            Assert.IsTrue(topic.Forum.Contains("Зарубежное кино (HD Video)"));
            Assert.AreEqual(topic.Uploader, "-DaRkY-");
            Assert.AreEqual(topic.Status, TopicStatus.Checked);
        }

        [Test]
        public void GetForum_Test()
        {
            var forum = RutrackerInfoProvider.GetForumInfo("http://rutracker.org/forum/viewforum.php?f=2295");

            var firstTopic = RutrackerInfoProvider.GetTopicInfo(forum.Topics.First().Url);
            var lastTopic = RutrackerInfoProvider.GetTopicInfo(forum.Topics.Last().Url);

            Assert.AreEqual(JsonConvert.SerializeObject(forum.Topics.First()), JsonConvert.SerializeObject(firstTopic));
            Assert.AreEqual(JsonConvert.SerializeObject(forum.Topics.Last()), JsonConvert.SerializeObject(lastTopic));

            Assert.IsTrue(firstTopic.Forum.Contains("Отечественный джаз (lossy)"));
        }
    }
}
