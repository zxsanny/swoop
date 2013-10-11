using uHelper.Extensions;
using uHelper.Properties;

namespace uHelper
{
    public class UHelperSettingsProvider : ISettingsProvider
    {
        //TODO: rewrite and use reflection so that we don't need to add manually every new single property
        readonly Settings Settings = new Settings();

        public string Username
        {
            get { return Settings.Username; }
            set { Settings.Username = value; Settings.Save(); }
        }

        public string Password
        {
            get { return Settings.Password; } 
            set { Settings.Password = value; Settings.Save(); }
        }
    }
}
