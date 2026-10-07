# Copilot Instructions

## Project Overview
Coding4Coffee is a comprehensive .NET 10 suite for building modern, localizable Windows Forms applications with MVVM support, configuration management, and command-based UI controls.

## C# Coding Standards
1. All comments must be in English
2. Prefer null propagation operator (`?.`) over null checks
3. Use primary constructors (C# 12+) when appropriate
4. Omit curly braces for single-statement if blocks (both success and error cases)
5. Follow field and property naming conventions (observe existing patterns)

## Command Support Controls Guidelines
Coding4Coffee.WinForms style guidelines for command-support controls:

1. NAMING CONVENTIONS:
   - Localizable Base: `LocalizableXxxControl` (inherits from WinForms Control)
   - With Command Support: `LocalizableXxxControlWithCommandSupport` (inherits from Localizable variant)
   - Commands: `XxxCommand` (e.g., `ShowContextHelpCommand`)
   - ToolStrip Variants: `LocalizableToolStripXxxWithCommandSupport`
   - Follow specific field and property naming conventions observed from existing code patterns

2. EVENT-HANDLING & PROPERTIES:
   - Separate `ICommand?` and `object?` fields for each command
   - Public Property with Getter/Setter for Command and CommandParameter
   - Private Event-Handler methods (e.g., `Command_CanExecuteChanged`)
   - Fluent `BindXxxCommand(ICommand, object?)` method for method chaining
   - `#region` for organization with multiple commands (e.g., DataGridView)
   - `DesignerSerializationVisibility(Hidden)` for Command-Properties where appropriate

3. DEFAULT PARAMETER FALLBACK:
   - Intelligent fallback: `CommandParameter ?? DefaultValue`
   - Examples: `SelectedItem` (ComboBox), `Text` (TextBox), `SelectedTab.Name` (TabControl), `Position` (BindingNavigator)
   - XML-Remarks explain the default fallback mechanism
   - Document the control-specific behavior in remarks

4. DEBOUNCE & EVENT ROUTING:
   - Debounce timer for continuous input (TextBox 300ms default, configurable minimum 50ms)
   - Use `SelectionChangeCommitted` instead of `SelectedIndexChanged` (user-only actions)
   - Route events through private handler methods
   - Proper Subscribe/Unsubscribe in Command setter and Dispose
   - Stop and dispose timers in Dispose method

5. XML DOCUMENTATION:
   - Extensive `<summary>`, `<remarks>`, `<param>`, `<returns>` tags
   - API links via `<see cref="..."/>`
   - Explain behavior in remarks section
   - Document intelligent default parameter behavior
   - Include example usage when appropriate

6. DISPOSE PATTERN:
   - Override `Dispose(bool)` for Timer and BindingSource cleanup
   - Unsubscribe from events before calling `base.Dispose()`
   - Stop timers before disposal

7. CONSTRUCTOR:
   - Event subscriptions in Constructor (e.g., for Timer Tick)
   - Actively initialize, do not use lazy loading
   - Initialize timers and event handlers immediately

## General Coding Preferences
- All comments must be in English
- Prefer null propagation operator (?.) over null checks
- Prefer primary constructors (C# 12+)
- Omit curly braces for if statements when both success and error blocks contain only a single statement