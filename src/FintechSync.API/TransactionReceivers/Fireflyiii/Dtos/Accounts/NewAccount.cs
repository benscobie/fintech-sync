using System.Text.Json.Serialization;

namespace FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Accounts
{
    public class NewAccount
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("active")]
        public bool Active => true;
    }
}
