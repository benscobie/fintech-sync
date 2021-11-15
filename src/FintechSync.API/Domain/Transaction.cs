namespace FintechSync.API.Domain
{
    public class Transaction
    {
        public DateTimeOffset Created { get; set; }

        public DateTimeOffset Settled { get; set; }

        public string Merchant { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; }

        public decimal ForeignAmount { get; set; }

        public string ForeignCurrency { get;set; }

        public TransactionSender TransactionSender { get; set; }
    }
}
