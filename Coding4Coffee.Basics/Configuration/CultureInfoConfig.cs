using System.Globalization;

namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores a <see cref="CultureInfo"/> as its culture name string.</summary>
    public class CultureInfoConfig : Config<string>
    {
        /// <summary>Gets or sets the value as a <see cref="CultureInfo"/>.</summary>
        public new CultureInfo? Value
        {
            get => base.Value != null ? CultureInfo.GetCultureInfo(base.Value) : default;
            set => base.Value = value?.Name;
        }

        /// <summary>Implicitly converts a <see cref="CultureInfoConfig"/> to a <see cref="CultureInfo"/>.</summary>
        public static implicit operator CultureInfo?(CultureInfoConfig config) => config.Value;
    }
}
