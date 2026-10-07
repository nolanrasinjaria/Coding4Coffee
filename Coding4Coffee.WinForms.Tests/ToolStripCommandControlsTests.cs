using System.Windows.Input;
using Coding4Coffee.WinForms.Commands.Controls;
using Xunit;

namespace Coding4Coffee.WinForms.Tests
{
    /// <summary>
    /// Test suite for ToolStrip controls with command binding support.
    /// </summary>
    public class ToolStripCommandControlsTests
    {
        #region Mock Command Implementation

        /// <summary>
        /// Mock ICommand for testing.
        /// </summary>
        private class MockCommand : ICommand
        {
            private bool _canExecute = true;

            public int ExecuteCount { get; private set; }
            public object? LastExecutedParameter { get; private set; }
            public bool MockCanExecute
            {
                get => _canExecute;
                set
                {
                    if (_canExecute != value)
                    {
                        _canExecute = value;
                        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
            }

            public event EventHandler? CanExecuteChanged;

            public bool CanExecute(object? parameter) => _canExecute;

            public void Execute(object? parameter)
            {
                if (CanExecute(parameter))
                {
                    ExecuteCount++;
                    LastExecutedParameter = parameter;
                }
            }
        }

        #endregion

        #region ToolStripComboBox Tests

        public class ToolStripComboBoxWithCommandSupportTests
        {
            [Fact]
            public void Constructor_CreatesInstance()
            {
                var comboBox = new LocalizableToolStripComboBoxWithCommandSupport();
                Assert.NotNull(comboBox);
                Assert.Null(comboBox.Command);
                Assert.Null(comboBox.CommandParameter);
            }

            [Fact]
            public void Command_WhenSet_UpdatesEnabledState()
            {
                var comboBox = new LocalizableToolStripComboBoxWithCommandSupport();
                var command = new MockCommand { MockCanExecute = true };

                comboBox.Command = command;

                Assert.True(comboBox.Enabled);
            }

            [Fact]
            public void Command_WhenCanExecuteChanges_UpdatesEnabledState()
            {
                var comboBox = new LocalizableToolStripComboBoxWithCommandSupport();
                var command = new MockCommand { MockCanExecute = true };
                comboBox.Command = command;

                Assert.True(comboBox.Enabled);

                command.MockCanExecute = false;
                Assert.False(comboBox.Enabled);

                command.MockCanExecute = true;
                Assert.True(comboBox.Enabled);
            }

            [Fact]
            public void BindCommand_ReturnsComboBoxForChaining()
            {
                var comboBox = new LocalizableToolStripComboBoxWithCommandSupport();
                var command = new MockCommand();
                var result = comboBox.BindCommand(command, "param");

                Assert.Same(comboBox, result);
                Assert.Same(command, comboBox.Command);
                Assert.Equal("param", comboBox.CommandParameter);
            }
        }

        #endregion

        #region ToolStripTextBox Tests

        public class ToolStripTextBoxWithCommandSupportTests
        {
            [Fact]
            public void Constructor_CreatesInstance()
            {
                var textBox = new LocalizableToolStripTextBoxWithCommandSupport();
                Assert.NotNull(textBox);
                Assert.Null(textBox.Command);
                Assert.Null(textBox.CommandParameter);
            }

            [Fact]
            public void Command_WhenSet_UpdatesEnabledState()
            {
                var textBox = new LocalizableToolStripTextBoxWithCommandSupport();
                var command = new MockCommand { MockCanExecute = true };

                textBox.Command = command;

                Assert.True(textBox.Enabled);
            }

            [Fact]
            public void Command_WhenCanExecuteChanges_UpdatesEnabledState()
            {
                var textBox = new LocalizableToolStripTextBoxWithCommandSupport();
                var command = new MockCommand { MockCanExecute = true };
                textBox.Command = command;

                Assert.True(textBox.Enabled);

                command.MockCanExecute = false;
                Assert.False(textBox.Enabled);

                command.MockCanExecute = true;
                Assert.True(textBox.Enabled);
            }

            [Fact]
            public void BindCommand_ReturnsTextBoxForChaining()
            {
                var textBox = new LocalizableToolStripTextBoxWithCommandSupport();
                var command = new MockCommand();
                var result = textBox.BindCommand(command, "param");

                Assert.Same(textBox, result);
                Assert.Same(command, textBox.Command);
                Assert.Equal("param", textBox.CommandParameter);
            }
        }

        #endregion

        #region ToolStripSplitButton Tests

        public class ToolStripSplitButtonWithCommandSupportTests
        {
            [Fact]
            public void Constructor_CreatesInstance()
            {
                var button = new LocalizableToolStripSplitButtonWithCommandSupport();
                Assert.NotNull(button);
                Assert.Null(button.Command);
                Assert.Null(button.CommandParameter);
            }

            [Fact]
            public void Command_WhenSet_UpdatesEnabledState()
            {
                var button = new LocalizableToolStripSplitButtonWithCommandSupport();
                var command = new MockCommand { MockCanExecute = true };

                button.Command = command;

                Assert.True(button.Enabled);
            }

            [Fact]
            public void Command_WhenCanExecuteChanges_UpdatesEnabledState()
            {
                var button = new LocalizableToolStripSplitButtonWithCommandSupport();
                var command = new MockCommand { MockCanExecute = true };
                button.Command = command;

                Assert.True(button.Enabled);

                command.MockCanExecute = false;
                Assert.False(button.Enabled);

                command.MockCanExecute = true;
                Assert.True(button.Enabled);
            }

            [Fact]
            public void BindCommand_ReturnsButtonForChaining()
            {
                var button = new LocalizableToolStripSplitButtonWithCommandSupport();
                var command = new MockCommand();
                var result = button.BindCommand(command, "param");

                Assert.Same(button, result);
                Assert.Same(command, button.Command);
                Assert.Equal("param", button.CommandParameter);
            }
        }

        #endregion
    }
}
