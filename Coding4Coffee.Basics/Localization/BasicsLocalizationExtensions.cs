using System.Resources;

namespace Coding4Coffee.Basics.Localization
{
    /// <summary>
    /// Extension methods and properties for localization in Basics.
    /// </summary>
    public static class BasicsLocalizationExtensions
    {
        /// <summary>
        /// Static property to hold the resource manager for localization.
        /// </summary>
        public static ResourceManager? ResourceManager { get; set; } = null;

        /// <summary>
        /// Gets the resource manager for localization.
        /// </summary>
        /// <param name="_">The target object instance (unused).</param>
        /// <returns>The resource manager to be used for localization.</returns>
        public static ResourceManager? GetResourceManager(this object _) => ResourceManager;
    }
}
