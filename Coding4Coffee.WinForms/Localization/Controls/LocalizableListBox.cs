using System.Collections;
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
