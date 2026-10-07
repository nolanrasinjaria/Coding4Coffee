using Coding4Coffee.Basics.Localization;
using Coding4Coffee.WinForms.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    /// <summary>
    /// A Panel control that supports dynamic localization of its child controls at runtime.
    /// </summary>
    public class LocalizablePanel : Panel, ILocalizable
    {
        /// <summary>
        /// Localizes all child controls contained within the panel.
        /// </summary>
        public void Localize() => Controls.LocalizeCollection();
    }
}
