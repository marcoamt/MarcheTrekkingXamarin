
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MrcheTrekking.Utility
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string Username = "user";
        private static readonly string SettingsDefault = string.Empty;

        #endregion


        public static string User
        {
            get
            {
                return AppSettings.GetValueOrDefault(Username, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(Username, value);
            }
        }

    }
}
