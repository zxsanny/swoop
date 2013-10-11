using System.Globalization;
using System.Net;
using NUnit.Framework;
using RutrackerAPI;

namespace webAPI.Rutracker.Tests
{
    [TestFixture]
    public class RutrackerInfoProviderTest
    {
        private const string username = "zxsanny";
        private const string password = "ifx342vfns";

        [TestCase("http://rutracker.org/forum/viewtopic.php?t=2339869", Result = "Зелёная миля / The Green Mile (Фрэнк Дарабонт / Frank Darabont) [1080p] [1999 г., Драма, BDRip]++18.57 GB++-DaRkY-")]
        public string GetSeedingInfo_Test(string url)
        {
            //ARRANGE
            var provider = new RutrackerInfoProvider();
            var trackerInfo = new NetworkCredential(username, password);
            
            //ACT
            var seedingInfo = provider.GetSeedingInfo(trackerInfo, url);
            
            //ASSERT
            //Assert.AreEqual("4", "23");
            return string.Format("{0}++{1}++{2}", seedingInfo.Name, seedingInfo.SizeGMKB.ToString(CultureInfo.InvariantCulture), seedingInfo.Uploader);
            
        }
    }
}
