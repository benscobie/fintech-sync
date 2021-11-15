using FintechSync.API.Receivers.Fireflyiii.Dtos.Transactions;
using FintechSync.API.TransactionReceivers.Fireflyiii;
using FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Autocomplete;

namespace FintechSync.API.Receivers.Fireflyiii
{
    public interface IFireflyiiiApiClient
    {
        Task NewTransactionAsync(RootTransaction transaction);
        void SetConfiguration(FireflyiiiConfiguration configuration);
        Task<List<Account>> SearchAccountsAsync(string searchTerm, string type);
    }
}