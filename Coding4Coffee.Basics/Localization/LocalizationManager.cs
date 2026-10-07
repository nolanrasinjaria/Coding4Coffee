using System.Globalization;
using Coding4Coffee.Basics.Configuration;

namespace Coding4Coffee.Basics.Localization
{
    /// <summary>
    /// Manages the application culture and notifies subscribers when it changes.
    /// </summary>
    public static class LocalizationManager
    {
        private static string _cultureConfigKey = string.Empty;

        /// <summary>
        /// Gets or sets the configuration key used to save/load the culture.
        /// </summary>
        public static string CultureConfigKey
        {
            get => _cultureConfigKey;
            set
            {
                if (_cultureConfigKey != value)
                {
                    _cultureConfigKey = value;
                    LoadCultureFromConfig();
                }
            }
        }

        static LocalizationManager() => LoadCultureFromConfig();

        private static void LoadCultureFromConfig()
        {
            if (string.IsNullOrWhiteSpace(CultureConfigKey)) return;

            try
            {
                var config = ConfigFactory.GetCultureInfoConfig(CultureConfigKey);
                if (config.HasValue)
                {
                    var culture = config.Value;
                    if (culture != null && CultureInfo.CurrentUICulture.Name != culture.Name)
                    {
                        CultureInfo.CurrentCulture = culture;
                        CultureInfo.CurrentUICulture = culture;
                        CultureChanged?.Invoke(null, EventArgs.Empty);
                    }
                }
            }
            catch
            {
                // Fallback / ignore if configuration or settings are not yet initialized
            }
        }

        /// <summary>
        /// Event raised when the current culture changes.
        /// </summary>
        public static event EventHandler? CultureChanged;

        /// <summary>
        /// Gets or sets the current UI culture of the application.
        /// </summary>
        public static CultureInfo CurrentCulture
        {
            get => CultureInfo.CurrentUICulture;
            set
            {
                if (CultureInfo.CurrentUICulture.Name != value.Name)
                {
                    CultureInfo.CurrentCulture = value;
                    CultureInfo.CurrentUICulture = value;

                    if (!string.IsNullOrWhiteSpace(CultureConfigKey))
                    {
                        try
                        {
                            var config = ConfigFactory.GetCultureInfoConfig(CultureConfigKey);
                            config.Value = value;
                        }
                        catch
                        {
                            // Ignore if settings are not writable or not initialized
                        }
                    }

                    CultureChanged?.Invoke(null, EventArgs.Empty);
                }
            }
        }
    }
}

