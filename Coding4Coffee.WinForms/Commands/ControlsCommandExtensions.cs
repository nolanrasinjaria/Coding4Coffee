using System.Windows.Input;

namespace Coding4Coffee.WinForms.Commands
{
    public static class ControlsCommandExtensions
    {
        public static void SetCommand(this ToolStripMenuItem control, ICommand command, object? parameter = null)
        {
            control.CommandParameter = parameter;
            control.Command = command;
        }

        public static void SetCommand(this ButtonBase control, ICommand command, object? parameter = null)
        {
            control.CommandParameter = parameter;
            control.Command = command;
        }
    }
}
