using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    public class LocalizableMenuStrip : MenuStrip, ILocalizable
    {
        public void Localize()
        {
            Items.LocalizeCollection();
        }
    }
}
