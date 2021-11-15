using System.Text.Json.Serialization;

namespace FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Autocomplete
{
    public class Account
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("name_with_balance")]
        public string NameWithBalance { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("currency_id")]
        public int CurrencyId { get; set; }

        [JsonPropertyName("currency_name")]
        public string CurrencyName { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("currency_decimal_places")]
        public int CurrencyDecimalPlaces { get; set; }
    }
}
