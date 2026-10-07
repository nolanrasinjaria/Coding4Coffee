# Coding4Coffee.WinForms

A modern Windows Forms library for .NET 10 providing localizable UI controls, MVVM-style command binding for controls, and form management commands.

## Features

- 🎨 **Localizable WinForms Controls**: Built-in dynamic localization support for 45 controls including `LocalizableForm`, `LocalizableButton`, `LocalizableLabel`, `LocalizableTextBox`, `LocalizableCheckBox`, `LocalizableRadioButton`, `LocalizableComboBox`, `LocalizableListBox`, `LocalizableCheckedListBox`, `LocalizableDataGridView`, `LocalizableGroupBox`, `LocalizableMenuStrip`, `LocalizableContextMenuStrip`, `LocalizableStatusStrip`, `LocalizableToolStrip`, and more.
- ⚡ **Command-Enabled Controls**: Binds `ICommand` implementations to standard WinForms controls (`ButtonBase.BindCommand()`, `ToolStripMenuItem.BindCommand()`, and `NumericUpDownWithCommandSupport`).
- 🚪 **Form Commands**: Reusable commands to open modeless forms with lifetime & activate management (`OpenFormCommand<TForm>`) and close forms (`CloseFormCommand`).
- 🎯 **WinForms Configuration**: Specialized configs for UI types with custom serialization (`ColorConfig`, `FontConfig`, `IconConfig`, `ImageConfig` via `WinFormsConfigFactory`), while standard types (`Point`, `Size`, `FormWindowState`) are supported directly through `ConfigFactory.GetConfig<T>()`.

## Installation

Install via NuGet Package Manager CLI:

```bash
dotnet add package Coding4Coffee.WinForms
```

## Quick Start

### 1. Localizable Controls & Forms

```csharp
using Coding4Coffee.Basics.Localization;
using Coding4Coffee.WinForms.Localization.Controls;

// 1. Assign application-wide ResourceManager
BasicsLocalizationExtensions.ResourceManager = MyResources.ResourceManager;

// 2. Derive forms from LocalizableForm:
// Automatically localizes the form and all contained ILocalizable child controls on Load
// and whenever LocalizationManager.CurrentCulture changes.
public class MainForm : LocalizableForm
{
	public MainForm()
	{
		TextResourceKey = "MainForm_Title";

		var saveButton = new LocalizableButton
		{
			TextResourceKey = "Btn_Save_Text",
			Text = "Save" // Fallback text
		};

		Controls.Add(saveButton);
	}
}
```

### 2. Command Binding & Form Commands

```csharp
using Coding4Coffee.WinForms.Commands;
using Coding4Coffee.WinForms.Commands.Controls;

// Bind an ICommand to any ButtonBase or ToolStripMenuItem
var saveButton = new Button();
saveButton.BindCommand(saveCommand, commandParameter);

var exitMenuItem = new ToolStripMenuItem();
exitMenuItem.BindCommand(new CloseFormCommand(this));

// Open a modeless form (creates form on first execution, restores & brings to front if open)
var openSettingsCommand = new OpenFormCommand<SettingsForm>();
openSettingsCommand.Execute(null);

// NumericUpDown with automatic command execution on ValueChanged
var numericUpDown = new NumericUpDownWithCommandSupport
{
	Command = updateValueCommand
};
```

### 3. UI Configuration (State & Drawing Types)

```csharp
using Coding4Coffee.Basics.Configuration;
using Coding4Coffee.WinForms.Configuration;
using System.Drawing;

// Standard types work directly with generic ConfigFactory.GetConfig<T>
var windowState = ConfigFactory.GetConfig<FormWindowState>("MainWindow_State");
var windowSize  = ConfigFactory.GetConfig<Size>("MainWindow_Size");

// Specialized WinForms types (Color, Font, Icon, Image) via WinFormsConfigFactory
var accentColor = WinFormsConfigFactory.GetColorConfig("App_AccentColor");
accentColor.Value = Color.DarkSlateBlue;
Color? color = accentColor; // Implicit conversion

var appFont = WinFormsConfigFactory.GetFontConfig("App_DefaultFont");
appFont.Value = new Font("Segoe UI", 10f);
Font? font = appFont; // Implicit conversion

var appIcon = WinFormsConfigFactory.GetIconConfig("App_WindowIcon");
appIcon.Value = SystemIcons.Application;
Icon? icon = appIcon; // Implicit conversion

var logoImage = WinFormsConfigFactory.GetImageConfig("App_LogoImage");
Image? logo = logoImage; // Implicit conversion
```

## Localizable Controls

The library provides localizable versions of 45 major WinForms controls:

### Standard Controls (10)
- `LocalizableButton`
- `LocalizableCheckBox`
- `LocalizableLabel`
- `LocalizableTextBox`
- `LocalizableRadioButton`
- `LocalizableForm`
- `LocalizableGroupBox`
- `LocalizableLinkLabel`
- `LocalizablePanel`
- `LocalizableUserControl`

### Selection Controls (9)
- `LocalizableListBox`
- `LocalizableCheckedListBox`
- `LocalizableComboBox`
- `LocalizableTreeView`
- `LocalizableTreeNode`
- `LocalizableListView`
- `LocalizableDomainUpDown`
- `LocalizableTabControl`
- `LocalizableTabPage`

### Data Display (2)
- `LocalizableDataGridView`
- `LocalizableColumnHeader`

### Text Input (2)
- `LocalizableRichTextBox`
- `LocalizableMaskedTextBox`

### Menus & Toolbars (13)
- `LocalizableMenuStrip`
- `LocalizableToolStripMenuItem`
- `LocalizableContextMenuStrip`
- `LocalizableToolStrip`
- `LocalizableToolStripButton`
- `LocalizableToolStripLabel`
- `LocalizableToolStripDropDownButton`
- `LocalizableToolStripSplitButton`
- `LocalizableToolStripTextBox`
- `LocalizableToolStripComboBox`
- `LocalizableStatusStrip`
- `LocalizableToolStripStatusLabel`
- `LocalizableBindingNavigator`

### Dialogs (3)
- `LocalizableFolderBrowserDialog`
- `LocalizableOpenFileDialog`
- `LocalizableSaveFileDialog`

### Other Controls (6)
- `LocalizableToolTip`
- `LocalizableHelpProvider`
- `LocalizableFlowLayoutPanel`
- `LocalizableSplitContainer`
- `LocalizableTableLayoutPanel`
- `LocalizableNotifyIcon`

## Command-Enabled Controls

### Built-in Extensions
- `ButtonBase.BindCommand()` - Extension for Button, CheckBox, RadioButton, etc.
- `ToolStripMenuItem.BindCommand()` - Extension for menu items

### Custom Command-Support Controls (21)

#### Standard Desktop Controls (3)
- `DateTimePickerWithCommandSupport` - Executes command on value change
- `NumericUpDownWithCommandSupport` - Executes command on value change
- `TrackBarWithCommandSupport` - Executes command on value change

#### Localizable Desktop Controls (12)
- `LocalizableCheckBoxWithCommandSupport`
- `LocalizableComboBoxWithCommandSupport` - Uses SelectionChangeCommitted for user-only changes + SelectedItem default
- `LocalizableCheckedListBoxWithCommandSupport`
- `LocalizableDomainUpDownWithCommandSupport`
- `LocalizableLinkLabelWithCommandSupport`
- `LocalizableListBoxWithCommandSupport`
- `LocalizableListViewWithCommandSupport`
- `LocalizableMaskedTextBoxWithCommandSupport`
- `LocalizableRadioButtonWithCommandSupport`
- `LocalizableRichTextBoxWithCommandSupport`
- `LocalizableTextBoxWithCommandSupport` - Debounced (300ms default) + Text default parameter
- `LocalizableTreeViewWithCommandSupport`

#### Specialized Controls (3)
- `LocalizableDataGridViewWithCommandSupport` - 7 independent commands: CellClick, CellDoubleClick, CellValueChanged (debounced), CellBeginEdit, CellEndEdit, SelectionChanged, RowHeaderClick
- `LocalizableTabControlWithCommandSupport` - Executes on tab selection change with SelectedTab.Name default
- `LocalizableBindingNavigatorWithCommandSupport` - 2 commands: ItemClicked (for navigation buttons), PositionChanged (for data position changes)

#### ToolStrip Controls (3)
- `LocalizableToolStripComboBoxWithCommandSupport` - Uses SelectionChangeCommitted + SelectedItem default
- `LocalizableToolStripSplitButtonWithCommandSupport` - Uses ButtonClick for button portion only
- `LocalizableToolStripTextBoxWithCommandSupport` - Debounced (300ms default) + Text default parameter

### Form Management Commands
- `OpenFormCommand<TForm>` - Opens or activates a modeless form
- `CloseFormCommand` - Closes a form
- `ShowContextHelpCommand` - Shows context help for a control

## Configuration Types

### Standard Types (via ConfigFactory)
- `Size`
- `Point`
- `FormWindowState`
- All types from `Coding4Coffee.Basics.Configuration`

### Specialized WinForms Types (via WinFormsConfigFactory)
- `Color` - with implicit conversion
- `Font` - with implicit conversion
- `Icon` - with implicit conversion
- `Image` - with implicit conversion

## API Reference

### WinFormsConfigFactory
- `GetColorConfig(string key)` - Get or create a Color configuration
- `GetFontConfig(string key)` - Get or create a Font configuration
- `GetIconConfig(string key)` - Get or create an Icon configuration
- `GetImageConfig(string key)` - Get or create an Image configuration

### LocalizableForm
- `TextResourceKey` - Gets or sets the resource key for the form title
- Automatically localizes all child `ILocalizable` controls
- Subscribes to culture change events

### Command Extensions & Fluent API
- `ButtonBase.BindCommand(ICommand command, object? parameter = null)` - Binds command to button
- `ToolStripMenuItem.BindCommand(ICommand command, object? parameter = null)` - Binds command to menu item
- Custom controls provide type-specific `Bind*Command()` methods for fluent chaining:
  - Single commands: `BindCommand(ICommand, object?)`
  - Multiple commands (e.g., DataGridView): `BindCellClickCommand()`, `BindCellDoubleClickCommand()`, `BindCellValueChangedCommand()`, etc.
  - Navigation: `BindItemClickedCommand()`, `BindPositionChangedCommand()` (BindingNavigator)

## Best Practices

1. **Always set fallback text** - Provide default text for controls in case the resource key is not found
2. **Use LocalizableForm** - Derive your main forms from `LocalizableForm` for automatic localization
3. **Resource naming** - Use a consistent naming convention for resource keys (e.g., `FormName_ControlName`)
4. **Persist configuration** - Assign `ConfigFactory.Settings` to enable automatic persistence of UI state
5. **Command parameters** - Pass relevant data as command parameters instead of storing state in the form

## License

Distributed under the MIT License.
