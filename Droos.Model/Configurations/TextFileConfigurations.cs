using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace Droos.Model
{
    public class TextFileConfigurations : IConfiguration
    {
        private readonly Dictionary<string, string> _settings;

        public TextFileConfigurations(string filePath)
        {
            _settings = LoadSettings(filePath);
        }

        private Dictionary<string, string> LoadSettings(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Configuration file not found: {filePath}");
            }

            var jsonData = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonData);
        }

        public string this[string key]
        {
            get => _settings.ContainsKey(key) ? _settings[key] : null;
            set => _settings[key] = value;
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
            private readonly TextFileConfigurations _configuration;
            private readonly string _key;

            public ConfigurationSection(TextFileConfigurations configuration, string key)
            {
                _configuration = configuration;
                _key = key;
            }

            public string this[string key]
            {
                get => _configuration[_key + ":" + key];
                set => _configuration[_key + ":" + key] = value;
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
