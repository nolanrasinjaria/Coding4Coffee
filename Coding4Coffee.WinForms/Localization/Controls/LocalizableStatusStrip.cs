using Coding4Coffee.Basics.Localization;
using Coding4Coffee.WinForms.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    /// <summary>
    /// A StatusStrip control that supports dynamic localization of its items at runtime.
    /// </summary>
    public class LocalizableStatusStrip : StatusStrip, ILocalizable
    {
        /// <summary>
        /// Localizes all status items contained within the StatusStrip.
        /// </summary>
        public void Localize() => Items.LocalizeCollection();
    }
}
