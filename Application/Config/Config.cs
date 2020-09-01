using System.IO;
using Application.Config.DataModels;
using Newtonsoft.Json;

namespace Application.Config
{
    public class Config
    {
        private const string ConfigFile = "config.json";
        private ConfigModel _config;

        public static Config Make()
        {
            return new Config();
        }

        public ConfigModel Get()
        {
            if (_config == null)
            {
                SetConfig();
            }

            return _config;
        }

        private void SetConfig()
        {
            using var file = File.OpenText(ConfigFile);
            using var reader = new JsonTextReader(file);

            var s = new JsonSerializer();
            _config = s.Deserialize<ConfigModel>(reader);
        }
    }
}