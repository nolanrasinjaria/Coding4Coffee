using System.ComponentModel;
using Coding4Coffee.Basics.Localization;

namespace Coding4Coffee.WinForms.Localization.Controls
{
    /// <summary>
    /// Configuration info for localizing a control's tooltip text.
    /// </summary>
    public class ToolTipLocalizationInfo
    {
        /// <summary>
        /// Gets or sets the control associated with the tooltip.
        /// </summary>
        public Control? TargetControl { get; set; }

        /// <summary>
        /// Gets or sets the resource key used to localize the tooltip text.
        /// </summary>
        public string ToolTipTextResourceKey { get; set; } = string.Empty;
    }

    /// <summary>
    /// A ToolTip component that supports dynamic localization of tooltips assigned to controls at runtime.
    /// </summary>
    public class LocalizableToolTip : ToolTip, ILocalizable
    {
        /// <summary>
        /// Gets the list of control tooltip localization configurations.
        /// </summary>
        [Category("Localization")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ToolTipLocalizationInfo> ToolTipLocalizations { get; } = [];

        /// <summary>
        /// Localizes tooltips assigned to controls using the associated resource manager.
        /// </summary>
        public void Localize()
        {
            var resourceManager = this.GetResourceManager();
            if (resourceManager == null) return;

            foreach (var info in ToolTipLocalizations)
            {
                if (info.TargetControl != null && !string.IsNullOrWhiteSpace(info.ToolTipTextResourceKey))
                {
                    string? currentTip = GetToolTip(info.TargetControl);
                    string? localizedTip = resourceManager.GetString(info.ToolTipTextResourceKey) ?? currentTip;
                    SetToolTip(info.TargetControl, localizedTip);
                }
            }
        }
    }
}
