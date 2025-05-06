using System.Windows.Input;

namespace Coding4Coffee.Basics.Commands
{
    /// <summary>
    /// Base class for commands that are always executable.
    /// </summary>
    public abstract class AlwaysExecutableCommand : ICommand
    {
        /// <summary>
        /// Event that is raised when the command's ability to execute changes.
        /// Will not be raised in this implementation.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { /* no operation intended */ }
            remove { /* no operation intended */ }
        }

        /// <summary>
        /// Returns whether the command can be executed.
        /// Always returns true in this implementation.
        /// </summary>
        /// <returns>always true</returns>
        public bool CanExecute(object? _) => true;

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">parameter value to be used for the individual execution</param>
        public abstract void Execute(object? parameter);
    }
}
