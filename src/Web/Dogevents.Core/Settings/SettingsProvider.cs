using Microsoft.Extensions.Configuration;

namespace Dogevents.Core.Settings
{
    public static class SettingsProvider
    {
        public static T GetConfigurationValue<T>(this IConfigurationRoot configuration, string section) where T : new()
        {
            T val = new T();
            return configuration.GetSection(section).Get<T>();
        }
    }
}