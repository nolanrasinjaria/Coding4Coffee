using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    public class LocalizableLabel : Label, ILocalizable
    {
        [Browsable(true)]
        [Category("Localization")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string? TextRessourceKey { get; set; }

        public void Localize()
        {
            if (!string.IsNullOrWhiteSpace(TextRessourceKey))
                Text = this.GetResourceManager()?.GetString(TextRessourceKey) ?? Text;
        }
    }
}
