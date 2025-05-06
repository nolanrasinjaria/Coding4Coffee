using System.ComponentModel;
using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    public class LocalizableForm : Form, ILocalizable
    {
        public LocalizableForm()
        {
            Load += LocalizableForm_Load;
        }

        private void LocalizableForm_Load(object? sender, EventArgs e) => Localize();

        [Browsable(true)]
        [Category("Localization")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? TextRessourceKey { get; set; }

        public void Localize()
        {
            if (!string.IsNullOrWhiteSpace(TextRessourceKey))
                Text = this.GetResourceManager()?.GetString(TextRessourceKey) ?? Text;

            Controls.LocalizeCollection();

            if (IsMdiContainer)
                MdiChildren.LocalizeCollection();
        }
    }
}
