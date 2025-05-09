using System.Configuration;
using System.Drawing;
using System.Globalization;

namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>
    /// Represents a configuration setting.
    /// </summary>
    /// <param name="key">Key under which that setting as saved within a .settings file</param>
    public class Config(string key)
    {
        /// <summary>
        /// The settings object that is used to save the configuration.
        /// </summary>
        public static SettingsBase? Settings { get; set; }

        /// <summary>
        /// Event that is raised when the value of the configuration changes.
        /// </summary>
        public event EventHandler? ValueChanged;

        /// <summary>
        /// The key under which the configuration is saved.
        /// </summary>
        public string Key { get; } = key;

        /// <summary>
        /// The value of the configuration.
        /// </summary>
        public string Value
        {
            get => Settings?[Key]?.ToString() ?? $"[{Key}]";
            set
            {
                if (Settings != null && value != Value)
                {
                    Settings[Key] = value;
                    Settings.Save();
                    ValueChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Indicates whether the configuration has a value.
        /// </summary>
        public bool HasValue => !string.IsNullOrWhiteSpace(Value) && !Value.Equals($"[{Key}]");

        /// <summary>
        /// The value of the configuration as an integer.
        /// </summary>
        public int IntValue
        {
            get => int.Parse(Value, CultureInfo.InvariantCulture);
            set => Value = value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The value of the configuration as an array of integers.
        /// </summary>
        public int[] IntArrayValue
        {
            get => [.. Value.Split(',').Select(s => int.Parse(s, CultureInfo.InvariantCulture))];
            set => Value = Value = string.Join(',', value.Select(n => n.ToString(CultureInfo.InvariantCulture)));
        }

        /// <summary>
        /// The value of the configuration as a double.
        /// </summary>
        public double DoubleValue
        {
            get => double.Parse(Value, CultureInfo.InvariantCulture);
            set => Value = value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The value of the configuration as a DateTime.
        /// </summary>
        public DateTime DateTimeValue
        {
            get => DateTime.Parse(Value, CultureInfo.InvariantCulture);
            set => Value = value.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// The value of the configuration as a TimeSpan.
        /// </summary>
        public TimeSpan TimeSpanValue
        {
            get => TimeSpan.Parse(Value, CultureInfo.InvariantCulture);
            set => Value = value.ToString();
        }

        /// <summary>
        /// The value of the configuration as a boolean.
        /// </summary>
        public bool BoolValue
        {
            get => bool.Parse(Value);
            set => Value = value.ToString();
        }

        /// <summary>
        /// The value of the configuration as a Color.
        /// </summary>
        public Color ColorValue
        {
            get => Color.FromArgb(IntValue);
            set => IntValue = value.ToArgb();
        }

        /// <summary>
        /// The value of the configuration as a Point.
        /// </summary>
        public Point PointValue
        {
            get
            {
                int[] numbers = IntArrayValue;
                return new Point(numbers[0], numbers[1]);
            }
            set => IntArrayValue = [value.X, value.Y];
        }

        /// <summary>
        /// The value of the configuration as a Size.
        /// </summary>
        public Size SizeValue
        {
            get
            {
                int[] numbers = IntArrayValue;
                return new Size(numbers[0], numbers[1]);
            }
            set => IntArrayValue = [value.Width, value.Height];
        }

        /// <summary>
        /// The value of the configuration as a CultureInfo.
        /// </summary>
        public CultureInfo CultureValue
        {
            get => CultureInfo.GetCultureInfo(Value);
            set => Value = value.Name;
        }

        public static implicit operator string(Config config) => config.Value;
        public static implicit operator int(Config config) => config.IntValue;
        public static implicit operator double(Config config) => config.DoubleValue;
        public static implicit operator DateTime(Config config) => config.DateTimeValue;
        public static implicit operator TimeSpan(Config config) => config.TimeSpanValue;
        public static implicit operator bool(Config config) => config.BoolValue;
        public static implicit operator Color(Config config) => config.ColorValue;
        public static implicit operator Point(Config config) => config.PointValue;
        public static implicit operator Size(Config config) => config.SizeValue;
        public static implicit operator CultureInfo(Config config) => config.CultureValue;
    }
}
