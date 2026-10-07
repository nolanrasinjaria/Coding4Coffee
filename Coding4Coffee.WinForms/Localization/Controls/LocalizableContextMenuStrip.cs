using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    /// <summary>
    /// A ContextMenuStrip control that supports dynamic localization of its menu items at runtime.
    /// </summary>
    public class LocalizableContextMenuStrip : ContextMenuStrip, ILocalizable
    {
        /// <summary>
        /// Localizes all menu items contained within the ContextMenuStrip.
        /// </summary>
        public void Localize() => Items.LocalizeCollection();
    }
}
