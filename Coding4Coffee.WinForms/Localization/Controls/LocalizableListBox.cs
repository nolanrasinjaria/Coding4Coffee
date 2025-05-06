using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    public class LocalizableListBox : ListBox, ILocalizable
    {
        public void Localize()
        {
            if(DataSource is IEnumerable collection)
                collection.LocalizeCollection();

            RefreshItems();
        }

        public void RefreshData() => RefreshItems();
    }
}
