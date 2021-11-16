using System.Text.Json.Serialization;

namespace FintechSync.API.Receivers.Fireflyiii.Dtos.Transactions
{
    public class TransactionGroup
    {
        [JsonPropertyName("error_if_duplicate_hash")]
        public bool ErrorIfDuplicateHash { get; set; }

        [JsonPropertyName("apply_rules")]
        public bool ApplyRules { get; set; }

        [JsonPropertyName("fire_webhooks")]
        public bool FireWebhooks { get; set; }

        [JsonPropertyName("group_title")]
        public string GroupTitle { get; set; }

        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }

    public class Transaction
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("date")]
        public DateTimeOffset? Date { get; set; }

        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("currency_id")]
        public int? CurrencyId { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("foreign_amount")]
        public string ForeignAmount { get; set; }

        [JsonPropertyName("foreign_currency_id")]
        public int? ForeignCurrencyId { get; set; }

        [JsonPropertyName("foreign_currency_code")]
        public string ForeignCurrencyCode { get; set; }

        [JsonPropertyName("budget_id")]
        public int? BudgetId { get; set; }

        [JsonPropertyName("category_id")]
        public int? CategoryId { get; set; }

        [JsonPropertyName("category_name")]
        public string CategoryName { get; set; }

        [JsonPropertyName("source_id")]
        public int SourceId { get; set; }

        [JsonPropertyName("source_name")]
        public string SourceName { get; set; }

        [JsonPropertyName("destination_id")]
        public int DestinationId { get; set; }

        [JsonPropertyName("destination_name")]
        public string DestinationName { get; set; }

        [JsonPropertyName("reconciled")]
        public bool Reconciled { get; set; }

        [JsonPropertyName("piggy_bank_id")]
        public int? PiggyBankId { get; set; }

        [JsonPropertyName("piggy_bank_name")]
        public string PiggyBankName { get; set; }

        [JsonPropertyName("bill_id")]
        public int? BillId { get; set; }

        [JsonPropertyName("bill_name")]
        public string BillName { get; set; }

        [JsonPropertyName("tags")]
        public string Tags { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("internal_reference")]
        public string InternalReference { get; set; }

        [JsonPropertyName("external_id")]
        public int? ExternalId { get; set; }

        [JsonPropertyName("bunq_payment_id")]
        public int? BunqPaymentId { get; set; }

        [JsonPropertyName("sepa_cc")]
        public string SepaCc { get; set; }

        [JsonPropertyName("sepa_ct_op")]
        public string SepaCtOp { get; set; }

        [JsonPropertyName("sepa_ct_id")]
        public int? SepaCtId { get; set; }

        [JsonPropertyName("sepa_db")]
        public string SepaDb { get; set; }

        [JsonPropertyName("sepa_country")]
        public string SepaCountry { get; set; }

        [JsonPropertyName("sepa_ep")]
        public string SepaEp { get; set; }

        [JsonPropertyName("sepa_ci")]
        public string SepaCi { get; set; }

        [JsonPropertyName("sepa_batch_id")]
        public int? SepaBatchId { get; set; }

        [JsonPropertyName("interest_date")]
        public DateTimeOffset? InterestDate { get; set; }

        [JsonPropertyName("book_date")]
        public DateTimeOffset? BookDate { get; set; }

        [JsonPropertyName("process_date")]
        public DateTimeOffset? ProcessDate { get; set; }

        [JsonPropertyName("due_date")]
        public DateTimeOffset? DueDate { get; set; }

        [JsonPropertyName("payment_date")]
        public DateTimeOffset? PaymentDate { get; set; }

        [JsonPropertyName("invoice_date")]
        public DateTimeOffset? InvoiceDate { get; set; }
    }
}
