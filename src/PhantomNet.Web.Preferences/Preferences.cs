using Microsoft.AspNet.Hosting;
using Microsoft.Framework.Configuration;
using Microsoft.Framework.Runtime;

namespace PhantomNet.Web.Preferences
{
    public static class Preferences
    {
        public static IConfiguration Configuration { get; set; }

        #region Settings

        public static string SiteName
        {
            get
            {
                return GetStringSetting("Site:Name");
            }
        }

        public static string FaviconVersion
        {
            get
            {
                return GetStringSetting("Site:FaviconVersion");
            }
        }

        public static string CustomerServiceName
        {
            get
            {
                return GetStringSetting("Contact:CustomerServiceName");
            }
        }

        public static string CustomerServiceEmail
        {
            get
            {
                return GetStringSetting("Contact:CustomerServiceEmail");
            }
        }

        public static string CustomerServiceEmailWithName
        {
            get
            {
                return string.Format("{0}<{1}>", CustomerServiceName, CustomerServiceEmail);
            }
        }

        public static string ContactEmailSubject
        {
            get
            {
                return GetStringSetting("Contact:EmailSubject");
            }
        }

        public static string GoogleAnalyticsId
        {
            get
            {
                return GetStringSetting("GoogleAnalytics:Id");
            }
        }

        public static string GoogleAnalyticsUrl
        {
            get
            {
                return GetStringSetting("GoogleAnalytics:Url");
            }
        }

        public static string FacebookAppId
        {
            get
            {
                return GetStringSetting("Facebook:AppId");
            }
        }

        public static string FacebookAppSecret
        {
            get
            {
                return GetStringSetting("Facebook:AppSecret");
            }
        }

        public static string GooglePlusId
        {
            get
            {
                return GetStringSetting("Seo:GooglePlusId");
            }
        }

        public static string GeoRegion
        {
            get
            {
                return GetStringSetting("Seo:GeoRegion");
            }
        }

        public static string GeoPosition
        {
            get
            {
                return GetStringSetting("Seo:GeoPosition");
            }
        }

        public static string Icbm
        {
            get
            {
                return GetStringSetting("Seo:Icbm");
            }
        }

        #endregion

        public static IConfiguration Init(IHostingEnvironment env, IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json")
                .AddJsonFile($"config.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets();
            }
            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
            return Configuration;
        }

        #region Helpers

        private static string GetStringSetting(string key)
        {
            try { return Configuration[key]; }
            catch { return default(string); }
        }

        #endregion
    }
}
