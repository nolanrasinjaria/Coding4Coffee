using System.Windows.Input;

namespace Coding4Coffee.WinForms.Commands
{
    /// <summary>
    /// Extension methods for setting commands on WinForms controls.
    /// </summary>
    public static class ControlsCommandExtensions
    {
        /// <summary>
        /// Binds a command and optional parameter to a <see cref="ToolStripMenuItem"/>.
        /// </summary>
        /// <remarks>
        /// Assigns <paramref name="command"/> and <paramref name="parameter"/> to the native
        /// <c>ToolStripMenuItem.Command</c> and <c>ToolStripMenuItem.CommandParameter</c> properties.
        /// </remarks>
        /// <param name="control">The <see cref="ToolStripMenuItem"/> instance to bind.</param>
        /// <param name="command">The command to assign.</param>
        /// <param name="parameter">The optional parameter value for the command.</param>
        /// <returns>The <paramref name="control"/> instance to support fluent method chaining.</returns>
        public static ToolStripMenuItem BindCommand(this ToolStripMenuItem control, ICommand command, object? parameter = null)
        {
            control.CommandParameter = parameter;
            control.Command = command;

            return control;
        }

        /// <summary>
        /// Binds a command and optional parameter to a <see cref="Button"/> control.
        /// </summary>
        /// <remarks>
        /// Intentionally targets <see cref="Button"/> rather than the broader <see cref="ButtonBase"/>.
        /// <see cref="CheckBox"/> and <see cref="RadioButton"/> also derive from <see cref="ButtonBase"/>,
        /// but their native <c>Command</c> fires on <c>Click</c> – not on <c>CheckedChanged</c>.
        /// Use <see cref="Controls.LocalizableCheckBoxWithCommandSupport"/> or
        /// <see cref="Controls.LocalizableRadioButtonWithCommandSupport"/> for those controls instead.
        /// </remarks>
        /// <param name="control">The <see cref="Button"/> instance to bind.</param>
        /// <param name="command">The command to assign.</param>
        /// <param name="parameter">The optional parameter value for the command.</param>
        /// <returns>The <paramref name="control"/> instance to support fluent method chaining.</returns>
        public static Button BindCommand(this Button control, ICommand command, object? parameter = null)
        {
            control.CommandParameter = parameter;
            control.Command = command;

            return control;
        }
    }
}
