using System.Net;

namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores an <see cref="IPAddress"/> as its string representation.</summary>
    public class IPAddressConfig : Config<string>
    {
        /// <summary>Gets or sets the value as an <see cref="IPAddress"/>.</summary>
        public new IPAddress? Value
        {
            get => base.Value != null && IPAddress.TryParse(base.Value, out var ip) ? ip : null;
            set => base.Value = value?.ToString();
        }

        /// <summary>Implicitly converts an <see cref="IPAddressConfig"/> to an <see cref="IPAddress"/>.</summary>
        public static implicit operator IPAddress?(IPAddressConfig config) => config.Value;
    }
}
