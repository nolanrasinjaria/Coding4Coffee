using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;

namespace Coding4Coffee.WinForms.Commands.Controls
{
    public class NumericUpDownWithCommandSupport : NumericUpDown
    {

        private ICommand? command;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ICommand? Command
        {
            get => command;
            set
            {
                if (command != null)
                {
                    command.CanExecuteChanged -= Command_CanExecuteChanged;
                    ValueChanged -= This_ValueChanged;
                }

                command = value;

                if (command != null)
                {
                    command.CanExecuteChanged += Command_CanExecuteChanged;
                    ValueChanged += This_ValueChanged;

                    Enabled = command.CanExecute(null);
                }
            }
        }

        private void Command_CanExecuteChanged(object? sender, EventArgs e) => Enabled = command?.CanExecute(null) ?? true;

        private void This_ValueChanged(object? sender, EventArgs e) => command?.Execute(Value);
    }
}
