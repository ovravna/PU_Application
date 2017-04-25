using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace PU_Application
{
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        private const string UsernameKey = "username";
        private static readonly string UsernameDefault = string.Empty;

        public static string Username
        {
            get => AppSettings.GetValueOrDefault(UsernameKey, UsernameDefault);
            set => AppSettings.AddOrUpdateValue(UsernameKey, value);
        }
    }
}
