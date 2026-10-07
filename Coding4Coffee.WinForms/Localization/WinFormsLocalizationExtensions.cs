using System.Collections;
using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization
{
    /// <summary>
    /// Extension methods for localizable objects.
    /// </summary>
    public static class WinFormsLocalizationExtensions
    {

        /// <summary>
        /// Localizes the elements of a collection and recursively traverses child elements of container controls.
        /// </summary>
        /// <remarks>
        /// If an element implements <see cref="ILocalizable"/>, its <see cref="ILocalizable.Localize"/> method is called.
        /// For common WinForms container and hierarchy types that do not implement <see cref="ILocalizable"/> directly
        /// (such as <see cref="ToolStrip"/>, <see cref="ToolStripDropDownItem"/>, <see cref="TreeView"/>, <see cref="TreeNode"/>,
        /// and nested child controls of standard <see cref="Control"/> instances), this method recursively traverses
        /// and localizes their contained items and controls.
        /// </remarks>
        /// <param name="collection">The collection containing elements to be localized.</param>
        public static void LocalizeCollection(this IEnumerable collection)
        {
            foreach (var item in collection)
            {
                if (item is ILocalizable localizable)
                    localizable.Localize();
                else if (item is ToolStrip toolStrip)
                    toolStrip.Items.LocalizeCollection();
                else if (item is ToolStripDropDownItem dropDownItem && dropDownItem.DropDownItems.Count > 0)
                    dropDownItem.DropDownItems.LocalizeCollection();
                else if (item is TreeView treeView && treeView.Nodes.Count > 0)
                    treeView.Nodes.LocalizeCollection();
                else if (item is TreeNode treeNode && treeNode.Nodes.Count > 0)
                    treeNode.Nodes.LocalizeCollection();
                else if (item is Control { Controls.Count: > 0 } standardControl)
                    standardControl.Controls.LocalizeCollection();
            }
        }
    }
}
