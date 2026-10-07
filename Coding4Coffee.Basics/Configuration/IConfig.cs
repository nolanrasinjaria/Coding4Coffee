namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>Represents a configuration setting.</summary>
    public interface IConfig
    {
        /// <summary>The key under which the configuration value is stored.</summary>
        public string Key { get; internal set; }
        /// <summary>Controls whether the configuration value is persisted.</summary>
        public bool IsTransient { get; set; }
        /// <summary>Indicates whether the configuration has a non-null value.</summary>
        public bool HasValue { get; }
        /// <summary>Indicates whether the configuration value equals the type default.</summary>
        public bool HasDefaultValue { get; }
    }
}
