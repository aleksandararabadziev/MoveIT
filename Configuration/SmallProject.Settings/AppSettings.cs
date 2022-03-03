using Microsoft.Extensions.Configuration;
using System.IO;

namespace SmallProject.Settings
{
    public class AppSettings
    {
        public bool TestAppSetting { get; set; }

        public string DbConnectionString { get; set; }

        public string WebApiUrl { get; set; }
    }

    public class AppSettingsLocator
    {
        private static AppSettings _appSettings;

        public static AppSettings Settings
        {
            get
            {
                if (_appSettings == null)
                {
                    _appSettings = GetAppSettings();
                }

                return _appSettings;
            }
        }

        public static AppSettings GetAppSettings()
        {
            var builder = new ConfigurationBuilder()
                         .SetBasePath(Directory.GetCurrentDirectory())
                         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                         .AddEnvironmentVariables();

            IConfiguration configuration = builder.Build();

            var settings = configuration.GetSection("Settings").Get<AppSettings>();

            return settings;
        }
    }
}
