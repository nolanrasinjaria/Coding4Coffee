namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>A <see cref="Config{T}"/> specialization that stores a <see cref="DirectoryInfo"/> as its full path string.</summary>
    public class DirectoryInfoConfig : Config<string>
    {
        /// <summary>Gets or sets the value as a <see cref="DirectoryInfo"/>.</summary>
        public new DirectoryInfo? Value
        {
            get => base.Value != null ? new DirectoryInfo(base.Value) : null;
            set => base.Value = value?.FullName;
        }

        /// <summary>Implicitly converts a <see cref="DirectoryInfoConfig"/> to a <see cref="DirectoryInfo"/>.</summary>
        public static implicit operator DirectoryInfo?(DirectoryInfoConfig config) => config.Value;
    }
}
