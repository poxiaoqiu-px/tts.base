using Microsoft.Extensions.Configuration;

namespace tts.extends.common
{
    public static class ConfigurationExtentions
    {
        private const string ConnectionStringKey = "ConnectionStrings:Default";

        public static string GetConnectionString(this IConfiguration config)
        {
            return config[ConnectionStringKey];
        }

        public static string GetConfig(this IConfiguration config, string key)
        {
            return config[key];
        }
    }
}
