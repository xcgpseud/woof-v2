using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Application.Config.DataModels
{
    public class BotModel
    {
        [JsonProperty("command-prefix")] public string CommandPrefix { get; set; }

        [JsonProperty("superusers")] public List<ulong> Superusers { get; set; }

        [JsonProperty("token")] public string Token { get; set; }
    }
}