using System.Text;

namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores a <see cref="System.Text.Encoding"/> as its WebName string representation.</summary>
    public class EncodingConfig : Config<string>
    {
        /// <summary>Gets or sets the value as a <see cref="System.Text.Encoding"/>.</summary>
        public new Encoding? Value
        {
            get => !string.IsNullOrEmpty(base.Value) ? Encoding.GetEncoding(base.Value) : null;
            set => base.Value = value?.WebName;
        }

        /// <summary>Implicitly converts an <see cref="EncodingConfig"/> to an <see cref="Encoding"/>.</summary>
        public static implicit operator Encoding?(EncodingConfig config) => config.Value;
    }
}
