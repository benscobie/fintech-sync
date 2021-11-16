using FintechSync.API.Receivers.Fireflyiii.Dtos.Transactions;
using FintechSync.API.TransactionReceivers.Fireflyiii;
using FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Accounts;

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

        private async Task<TransactionGroup> MapTransactionAsync(Domain.Transaction transaction)
        {
            var theTransaction =
                    new Dtos.Transactions.Transaction
                    {
                        Amount = Math.Abs(transaction.Amount).ToString(),
                        CurrencyCode = transaction.Currency,
                        ForeignCurrencyCode = transaction.ForeignCurrency,
                        ForeignAmount = transaction.ForeignAmount.ToString(),
                        Date = transaction.Created,
                        Description = transaction.Description,
                        Order = 1
                    };

            var accountId = await GetAccountId(transaction);
            if (transaction.Amount < 0)
            {
                theTransaction.Type = "withdrawal";
                theTransaction.DestinationId = accountId;
                theTransaction.SourceId = _config.SourceAccountId;
            } else
            {
                theTransaction.Type = "deposit";
                theTransaction.SourceId = accountId;
                theTransaction.DestinationId = _config.SourceAccountId;
            }

            return new TransactionGroup
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

        private async Task<int> GetAccountId(Domain.Transaction transaction)
        {
            var accountType = transaction.Amount < 0 ? "expense" : "revenue";
            var accounts = await _client.SearchAccountsAsync(transaction.Merchant, accountType);

            int destinationId;
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
                var newAccount = new NewAccount
                {
                    Name = transaction.Merchant,
                    Type = accountType,
                };

                var account = await _client.NewAccountAsync(newAccount);
                destinationId = account.Data.Id;
            }

            return destinationId;
        }
    }
}
