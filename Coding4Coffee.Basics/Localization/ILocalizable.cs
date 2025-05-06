namespace Coding4Coffee.Basics.Localization
{
    /// <summary>
    /// Interface for objects that are to be localized dynamically at runtime.
    /// </summary>
    public interface ILocalizable
    {
        /// <summary>
        /// Method to be called when the culture of the localizable object changes.
        /// </summary>
        void Localize();
    }
}
