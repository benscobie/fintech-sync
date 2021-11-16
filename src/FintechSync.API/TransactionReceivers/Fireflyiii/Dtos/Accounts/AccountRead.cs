using System.Text.Json.Serialization;

namespace FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Accounts
{
    public class AccountReadAttributes
    {
        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("order")]
        public int? Order { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("account_role")]
        public string AccountRole { get; set; }

        [JsonPropertyName("currency_id")]
        public string CurrencyId { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("currency_symbol")]
        public string CurrencySymbol { get; set; }

        [JsonPropertyName("currency_decimal_places")]
        public int? CurrencyDecimalPlaces { get; set; }

        [JsonPropertyName("current_balance")]
        public string CurrentBalance { get; set; }

        [JsonPropertyName("current_balance_date")]
        public DateTimeOffset CurrentBalanceDate { get; set; }

        [JsonPropertyName("iban")]
        public string Iban { get; set; }

        [JsonPropertyName("bic")]
        public string Bic { get; set; }

        [JsonPropertyName("account_number")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("opening_balance")]
        public string OpeningBalance { get; set; }

        [JsonPropertyName("current_debt")]
        public string CurrentDebt { get; set; }

        [JsonPropertyName("opening_balance_date")]
        public DateTimeOffset? OpeningBalanceDate { get; set; }

        [JsonPropertyName("virtual_balance")]
        public string VirtualBalance { get; set; }

        [JsonPropertyName("include_net_worth")]
        public bool IncludeNetWorth { get; set; }

        [JsonPropertyName("credit_card_type")]
        public string CreditCardType { get; set; }

        [JsonPropertyName("monthly_payment_date")]
        public DateTimeOffset? MonthlyPaymentDate { get; set; }

        [JsonPropertyName("liability_type")]
        public string LiabilityType { get; set; }

        [JsonPropertyName("liability_direction")]
        public string LiabilityDirection { get; set; }

        [JsonPropertyName("interest")]
        public string Interest { get; set; }

        [JsonPropertyName("interest_period")]
        public string InterestPeriod { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("zoom_level")]
        public int? ZoomLevel { get; set; }
    }

    public class AccountReadData
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("attributes")]
        public AccountReadAttributes Attributes { get; set; }
    }

    public class AccountRead
    {
        [JsonPropertyName("data")]
        public AccountReadData Data { get; set; }
    }
}
