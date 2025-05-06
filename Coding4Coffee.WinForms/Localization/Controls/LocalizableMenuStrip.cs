using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
