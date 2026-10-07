namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores a <see cref="FileInfo"/> as its full path string.</summary>
    public class FileInfoConfig : Config<string>
    {
        /// <summary>Gets or sets the value as a <see cref="FileInfo"/>.</summary>
        public new FileInfo? Value
        {
            get => base.Value != null ? new FileInfo(base.Value) : null;
            set => base.Value = value?.FullName;
        }

        /// <summary>Implicitly converts a <see cref="FileInfoConfig"/> to a <see cref="FileInfo"/>.</summary>
        public static implicit operator FileInfo?(FileInfoConfig config) => config.Value;
    }
}
