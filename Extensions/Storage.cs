namespace uHelper.Extensions
{
    public sealed class Storage
    {
        static Storage() {}

        private Storage() {}

        private static readonly Storage instance = new Storage();
        public static Storage Instance { get { return instance; } }

        public string Cookies { get; set; }
    }
}
