using Coding4Coffee.Basics.Configuration;

namespace Coding4Coffee.WinForms.Configuration
{
    /// <summary>
    /// Factory helpers for WinForms-specific configuration settings.
    /// </summary>
    public static class WinFormsConfigFactory
    {
        /// <summary>
        /// Gets or creates a <see cref="ColorConfig"/> for the specified key.
        /// </summary>
        /// <remarks>
        /// Instances are cached and reused by <paramref name="key"/> via <see cref="ConfigFactory.GetCustomConfig{TConfig}"/>.
        /// If the key was previously associated with a different configuration type, an <see cref="InvalidOperationException"/> is thrown.
        /// </remarks>
        /// <param name="key">The key under which the configuration value is stored.</param>
        /// <param name="isTransient">If <see langword="true"/>, the setting is kept in memory only and not persisted to settings.</param>
        /// <returns>The <see cref="ColorConfig"/> instance associated with <paramref name="key"/>.</returns>
        public static ColorConfig GetColorConfig(string key, bool isTransient = false) =>
            ConfigFactory.GetCustomConfig<ColorConfig>(key, isTransient);

        /// <summary>
        /// Gets or creates a <see cref="FontConfig"/> for the specified key.
        /// </summary>
        /// <remarks>
        /// Instances are cached and reused by <paramref name="key"/> via <see cref="ConfigFactory.GetCustomConfig{TConfig}"/>.
        /// If the key was previously associated with a different configuration type, an <see cref="InvalidOperationException"/> is thrown.
        /// </remarks>
        /// <param name="key">The key under which the configuration value is stored.</param>
        /// <param name="isTransient">If <see langword="true"/>, the setting is kept in memory only and not persisted to settings.</param>
        /// <returns>The <see cref="FontConfig"/> instance associated with <paramref name="key"/>.</returns>
        public static FontConfig GetFontConfig(string key, bool isTransient = false) =>
            ConfigFactory.GetCustomConfig<FontConfig>(key, isTransient);

        /// <summary>
        /// Gets or creates an <see cref="IconConfig"/> for the specified key.
        /// </summary>
        /// <remarks>
        /// Instances are cached and reused by <paramref name="key"/> via <see cref="ConfigFactory.GetCustomConfig{TConfig}"/>.
        /// If the key was previously associated with a different configuration type, an <see cref="InvalidOperationException"/> is thrown.
        /// </remarks>
        /// <param name="key">The key under which the configuration value is stored.</param>
        /// <param name="isTransient">If <see langword="true"/>, the setting is kept in memory only and not persisted to settings.</param>
        /// <returns>The <see cref="IconConfig"/> instance associated with <paramref name="key"/>.</returns>
        public static IconConfig GetIconConfig(string key, bool isTransient = false) =>
            ConfigFactory.GetCustomConfig<IconConfig>(key, isTransient);

        /// <summary>
        /// Gets or creates an <see cref="ImageConfig"/> for the specified key.
        /// </summary>
        /// <remarks>
        /// Instances are cached and reused by <paramref name="key"/> via <see cref="ConfigFactory.GetCustomConfig{TConfig}"/>.
        /// If the key was previously associated with a different configuration type, an <see cref="InvalidOperationException"/> is thrown.
        /// </remarks>
        /// <param name="key">The key under which the configuration value is stored.</param>
        /// <param name="isTransient">If <see langword="true"/>, the setting is kept in memory only and not persisted to settings.</param>
        /// <returns>The <see cref="ImageConfig"/> instance associated with <paramref name="key"/>.</returns>
        public static ImageConfig GetImageConfig(string key, bool isTransient = false) =>
            ConfigFactory.GetCustomConfig<ImageConfig>(key, isTransient);
    }
}
