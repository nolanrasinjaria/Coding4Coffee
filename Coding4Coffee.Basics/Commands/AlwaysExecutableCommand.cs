using System.Windows.Input;

namespace Coding4Coffee.Basics.Commands
{
    /// <summary>
    /// Provides an abstract base class for <see cref="ICommand"/> implementations that are always in an executable state.
    /// </summary>
    public abstract class AlwaysExecutableCommand : ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        /// <remarks>
        /// Because this command is always executable, subscriptions to this event are not necessary.
        /// The event is provided only to fulfill the ICommand contract. It is never raised.
        /// </remarks>
        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="_">The data used by the command. This parameter is ignored in this implementation.</param>
        /// <returns><see langword="true"/> in all cases, as this command is always executable.</returns>
        public bool CanExecute(object? _) => true;

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null"/>.</param>
        public abstract void Execute(object? parameter);
    }
}
