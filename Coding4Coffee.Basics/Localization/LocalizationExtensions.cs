using System.Collections;
using System.Resources;

namespace Coding4Coffee.Basics.Localization
{
    /// <summary>
    /// Extension methods for localizable objects.
    /// </summary>
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Static property to hold the resource manager for localization.
        /// </summary>
        public static ResourceManager? ResourceManager { get; set; } = null;

        /// <summary>
        /// Gets the resource manager for localization.
        /// </summary>
        /// <returns>The resource manager to be used for localization</returns>
        public static ResourceManager? GetResourceManager(this object _) => ResourceManager;

        /// <summary>
        /// Localizes the elements of a collection.
        /// </summary>
        /// <param name="collection">a collection that is to be localized</param>
        public static void LocalizeCollection(this IEnumerable collection)
        {
            foreach (var item in collection)
            {
                if (item is ILocalizable localizable)
                    localizable.Localize();
            }
        }
    }
}
