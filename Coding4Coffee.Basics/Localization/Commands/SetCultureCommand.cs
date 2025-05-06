using System.Globalization;
using System.Windows.Input;
using Coding4Coffee.Basics.Configuration;

namespace Coding4Coffee.Basics.Localization.Commands
{
    /// <summary>
    /// Command to set the culture of a localizable object.
    /// </summary>
    /// <param name="localizable">The localizable object that is to notify when the command is executed.</param>
    /// <param name="cultureConfigKey">The key under which the culture is saved in config files</param>
    public class SetCultureCommand(ILocalizable localizable, string cultureConfigKey) : ICommand
    {
        private readonly Config cultureConfig = ConfigFactory.GetConfig(cultureConfigKey);
        private readonly ILocalizable localizable = localizable;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => parameter is string cultureName && cultureName != cultureConfig;

        public void Execute(object? parameter)
        {
            if (parameter is string cultureName)
            {
                CultureInfo culture = CultureInfo.GetCultureInfo(cultureName);

                CultureInfo.CurrentUICulture = culture;
                cultureConfig.CultureValue = culture;

                localizable.Localize();

                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
