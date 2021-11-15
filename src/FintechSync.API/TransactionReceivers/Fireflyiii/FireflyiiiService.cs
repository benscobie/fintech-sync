using FintechSync.API.Receivers.Fireflyiii.Dtos.Transactions;
using FintechSync.API.TransactionReceivers.Fireflyiii;

namespace FintechSync.API.Receivers.Fireflyiii
{
    public class FireflyiiiService : ITransactionReceiver, IFireflyiiiService
    {
        private readonly IFireflyiiiApiClient _client;
        private FireflyiiiConfiguration _config;

        public FireflyiiiService(IFireflyiiiApiClient client)
        {
            _client = client;
        }

        public void SetConfiguration(FireflyiiiConfiguration configuration)
        {
            _config = configuration;
            _client.SetConfiguration(configuration);
        }

        public async Task PostTransactionAsync(Domain.Transaction transaction)
        {
            var fireflyTransaction = await MapTransactionAsync(transaction);
            await _client.NewTransactionAsync(fireflyTransaction);
        }

        private async Task<RootTransaction> MapTransactionAsync(Domain.Transaction transaction)
        {
            var theTransaction =
                    new Dtos.Transactions.Transaction
                    {
                        Type = transaction.Amount < 0 ? "withdrawal" : "deposit",
                        Amount = Math.Abs(transaction.Amount).ToString(),
                        CurrencyCode = transaction.Currency,
                        ForeignCurrencyCode = transaction.ForeignCurrency,
                        ForeignAmount = transaction.ForeignAmount.ToString(),
                        Date = transaction.Created,
                        Description = transaction.Description,
                        Order = 1
                    };

            var accounts = await _client.SearchAccountsAsync(transaction.Merchant, transaction.Amount < 0 ? "expense" : "revenue");

            string destinationId;
            if (accounts.Count == 1)
            {
                destinationId = accounts.Single().Id;
            }
            else if (accounts.Count > 1)
            {
                var closestMatch = accounts.SingleOrDefault(x => x.Name.Equals(transaction.Merchant, StringComparison.CurrentCultureIgnoreCase));
                if (closestMatch != null)
                {
                    destinationId = closestMatch.Id;
                }
                else
                {
                    destinationId = accounts.First().Id;
                }
            }
            else
            {
                // TODO Create an account
                throw new NotImplementedException();
            }

            theTransaction.DestinationId = destinationId;
            theTransaction.SourceId = _config.SourceAccountId;

            return new RootTransaction
            {
                ApplyRules = true,
                ErrorIfDuplicateHash = true,
                FireWebhooks = true,
                Transactions = new List<Dtos.Transactions.Transaction>
                {
                    theTransaction
                }
            };
        }
    }
}
