using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Coding4Coffee.WinForms.Commands
{
    public class CloseFormCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => parameter is Form form && form != null;

        public void Execute(object? parameter)
        {
            if (parameter is Form form)
                form.Close();

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
