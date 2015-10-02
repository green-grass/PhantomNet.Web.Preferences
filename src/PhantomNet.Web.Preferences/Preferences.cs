namespace PhantomNet.Web.Preferences
{
    public class Preferences
    {
        public string SiteName { get; set; }

        public string FaviconVersion { get; set; }

        public ContactSettings Contact { get; set; } = new ContactSettings();

        public GoogleAnalyticsSettings GoogleAnalytics { get; set; } = new GoogleAnalyticsSettings();

        public FacebookAppSettings FacebookApp { get; set; } = new FacebookAppSettings();

        public SeoSettings Seo { get; set; } = new SeoSettings();
    }

    public class ContactSettings
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string EmailWithName
        {
            get
            {
                return string.Format("{0}<{1}>", Name, Email);
            }
        }

        public string EmailSubject { get; set; }
    }

    public class GoogleAnalyticsSettings
    {
        public string Id { get; set; }

        public string Url { get; set; }
    }

    public class FacebookAppSettings
    {
        public string AppId { get; set; }

        public string AppSecret { get; set; }
    }

    public class SeoSettings
    {
        public string GooglePlusId { get; set; }

        public string GeoRegion { get; set; }

        public string GeoPosition { get; set; }

        public string Icbm { get; set; }
    }
}
