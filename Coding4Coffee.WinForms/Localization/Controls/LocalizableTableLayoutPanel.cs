using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    public class LocalizableTableLayoutPanel : TableLayoutPanel, ILocalizable
    {
        public void Localize()
        {
            Controls.LocalizeCollection();
        }
    }
}
