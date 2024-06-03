using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace Droos.Model
{



    public class EnvironmentVariablesConfigurations : IConfiguration
    {
        private readonly Dictionary<string, string> _settings;

        public EnvironmentVariablesConfigurations()
        {

        }

        public string this[string key]
        {

            get
            {
                var variable = Environment.GetEnvironmentVariable(key);
                return variable == null ? "" : variable;
            }
            set
            {
                Environment.SetEnvironmentVariable(key, value);
            }
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return new List<IConfigurationSection>();
        }

        public IChangeToken GetReloadToken()
        {
            return null;
        }

        public IConfigurationSection GetSection(string key)
        {
            return new ConfigurationSection(this, key);
        }

        private class ConfigurationSection : IConfigurationSection
        {
            private readonly EnvironmentVariablesConfigurations _configuration;
            private readonly string _key;

            public ConfigurationSection(EnvironmentVariablesConfigurations configuration, string key)
            {
                _configuration = configuration;
                _key = key;
            }

            public string this[string key]
            {
                get
                {
                    var variable = Environment.GetEnvironmentVariable(key);
                    return variable == null ? "" : variable;
                }
                set
                {
                    Environment.SetEnvironmentVariable(key, value);
                }
            }

            public string Key => _key;

            public string Path => _key;

            public string Value
            {
                get => _configuration[_key];
                set => _configuration[_key] = value;
            }

            public IEnumerable<IConfigurationSection> GetChildren()
            {
                return new List<IConfigurationSection>();
            }

            public IChangeToken GetReloadToken()
            {
                return null;
            }

            public IConfigurationSection GetSection(string key)
            {
                return new ConfigurationSection(_configuration, _key + ":" + key);
            }
        }
    }


}
