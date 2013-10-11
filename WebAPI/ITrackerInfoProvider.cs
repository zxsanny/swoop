using System.IO;
using System.Net;
using System.Windows.Forms;
using uHelper.webAPI.Domains;

namespace uHelper.webAPI
{
    public interface ITrackerInfoProvider
    {
        TopicInfo GetTopicInfo(string topicUrl);
        ForumInfo GetForumInfo(string forumUrl);
        Stream GetTorrentFile(string url, out string filename);
    }

    public abstract class BaseTrackerInfoProvider : ITrackerInfoProvider
    {
        public abstract TopicInfo GetTopicInfo(string topicUrl);
        public abstract ForumInfo GetForumInfo(string forumUrl);

        public abstract Stream GetTorrentFile(string url, out string filename);
        
        
        protected CredentialAndCaptcha GetCaptcha(NetworkCredential oldCredential, string captchaUrl)
        {
            using (var form = new EnterCaptchaForm(oldCredential, captchaUrl))
            {
                if (form.ShowDialog() != DialogResult.OK)
                    return null;
                return form.CredentialAndCaptcha;
            }
        }
    }
}