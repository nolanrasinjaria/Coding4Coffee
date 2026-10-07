using System;

namespace Coding4Coffee.Basics.Commands
{
    /// <summary>
    /// Provides data for the AsyncCommandBase execution error event.
    /// </summary>
    public class AsyncCommandErrorEventArgs(Exception exception, object? parameter) : EventArgs
    {
        /// <summary>
        /// Gets the exception that occurred during command execution.
        /// </summary>
        public Exception Exception { get; } = exception ?? throw new ArgumentNullException(nameof(exception));

        /// <summary>
        /// Gets the parameter that was passed to the command when execution failed.
        /// </summary>
        public object? Parameter { get; } = parameter;

        /// <summary>
        /// Gets or sets a value indicating whether the exception has been handled by the subscriber.
        /// </summary>
        /// <remarks>
        /// When set to <see langword="true"/>, the exception is considered handled and further processing may be skipped.
        /// Set to <see langword="false"/> by default, meaning the exception is unhandled.
        /// </remarks>
        public bool Handled { get; set; }
    }

    /// <summary>
    /// Provides data for async command progress reporting.
    /// </summary>
    /// <typeparam name="TProgress">The type of progress value being reported.</typeparam>
    public class AsyncCommandProgressEventArgs<TProgress>(TProgress progress, object? parameter) : EventArgs
    {
        /// <summary>
        /// Gets the progress value reported by the command.
        /// </summary>
        public TProgress Progress { get; } = progress;

        /// <summary>
        /// Gets the parameter that was passed to the command.
        /// </summary>
        public object? Parameter { get; } = parameter;

        /// <summary>
        /// Gets the timestamp when the progress was reported.
        /// </summary>
        public DateTime ReportedAt { get; } = DateTime.UtcNow;
    }
}
