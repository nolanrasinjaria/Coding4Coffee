namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores a <see cref="System.Version"/> as its string representation.</summary>
    public class VersionConfig : Config<string>
    {
        /// <summary>Gets or sets the value as a <see cref="System.Version"/>.</summary>
        public new Version? Value
        {
            get => base.Value != null && Version.TryParse(base.Value, out var version) ? version : null;
            set => base.Value = value?.ToString();
        }

        /// <summary>Implicitly converts a <see cref="VersionConfig"/> to a <see cref="System.Version"/>.</summary>
        public static implicit operator Version?(VersionConfig config) => config.Value;
    }
}
