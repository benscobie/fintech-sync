using FintechSync.API.Receivers.Fireflyiii.Dtos.Transactions;
using FintechSync.API.TransactionReceivers.Fireflyiii;
using FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Accounts;
using FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Autocomplete;

namespace FintechSync.API.Receivers.Fireflyiii
{
    public interface IFireflyiiiApiClient
    {
        Task NewTransactionAsync(TransactionGroup transaction);
        void SetConfiguration(FireflyiiiConfiguration configuration);
        Task<List<Account>> SearchAccountsAsync(string searchTerm, string type);
        Task<AccountRead> NewAccountAsync(NewAccount newAccount);
    }
}