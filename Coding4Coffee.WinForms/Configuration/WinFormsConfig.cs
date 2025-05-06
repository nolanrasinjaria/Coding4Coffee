using Coding4Coffee.Basics.Configuration;

namespace Coding4Coffee.WinForms.Configuration
{
    public class WinFormsConfig(string key) : Config(key)
    {
        public FormWindowState WindowStateValue
        {
            get => Value switch
            {
                nameof(FormWindowState.Maximized) => FormWindowState.Maximized,
                nameof(FormWindowState.Minimized) => FormWindowState.Minimized,
                _ => FormWindowState.Normal,
            };
            set => Value = value.ToString();
        }
    }
}
