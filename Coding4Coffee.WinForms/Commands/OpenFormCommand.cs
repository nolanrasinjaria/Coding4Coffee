using System.Windows.Input;

namespace Coding4Coffee.WinForms.Commands
{
    public class OpenFormCommand<FormType>(bool openAsDialog = false) : ICommand
        where FormType : Form, new()
    {
        private readonly bool openAsDialog = openAsDialog;

        protected FormType? ManagedForm { get; private set; } = null;

        public virtual event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter)
        {
            if (ManagedForm == null)
            {
                ManagedForm = new();
                ManagedForm.FormClosed += ManagedForm_FormClosed;

                if (parameter is Form mdiParent && mdiParent.IsMdiContainer)
                    ManagedForm.MdiParent = mdiParent;

                if (openAsDialog)
                    ManagedForm.ShowDialog();
                else
                    ManagedForm.Show();

                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
            else
                ManagedForm.Focus();
        }

        private void ManagedForm_FormClosed(object? sender, FormClosedEventArgs e) => ManagedForm = null;
    }
}
