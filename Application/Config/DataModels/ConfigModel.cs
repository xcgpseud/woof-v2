using Newtonsoft.Json;

namespace Application.Config.DataModels
{
    public class ConfigModel
    {
        [JsonProperty("bot")] public BotModel Bot { get; set; }
    }
}