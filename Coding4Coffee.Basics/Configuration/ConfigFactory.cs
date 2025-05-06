using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding4Coffee.Basics.Configuration
{
    /// <summary>
    /// Factory class for creating and managing configuration settings.
    /// </summary>
    public static class ConfigFactory
    {
        private static readonly Dictionary<string, Config> configs = [];

        /// <summary>
        /// Creates or retrieves a configuration setting by its key.
        /// </summary>
        /// <param name="key">The key under which the config value is saved</param>
        /// <returns></returns>
        public static Config GetConfig(string key)
        {
            if (!configs.TryGetValue(key, out Config? config))
            {
                config = new(key);
                configs.Add(key, config);
            }

            return config;
        }
    }
}
