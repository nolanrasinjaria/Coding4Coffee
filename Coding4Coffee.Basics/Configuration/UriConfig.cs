    namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores a <see cref="System.Uri"/> as its absolute string representation.</summary>
    public class UriConfig : Config<string>
    {
        /// <summary>Gets or sets the value as a <see cref="System.Uri"/>.</summary>
        public new Uri? Value
        {
            get => base.Value != null && Uri.TryCreate(base.Value, UriKind.RelativeOrAbsolute, out var uri) ? uri : null;
            set => base.Value = value?.ToString();
        }

        /// <summary>Implicitly converts a <see cref="UriConfig"/> to a <see cref="System.Uri"/>.</summary>
        public static implicit operator Uri?(UriConfig config) => config.Value;
    }
}
