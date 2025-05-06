using System.ComponentModel;
using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    public class LocalizableToolStripMenuItem : ToolStripMenuItem, ILocalizable
    {
        [Browsable(true)]
        [Category("Localization")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? TextRessourceKey { get; set; }

        public void Localize()
        {
            if (!string.IsNullOrWhiteSpace(TextRessourceKey))
                Text = this.GetResourceManager()?.GetString(TextRessourceKey) ?? Text;

            DropDownItems.LocalizeCollection();
        }
    }
}
