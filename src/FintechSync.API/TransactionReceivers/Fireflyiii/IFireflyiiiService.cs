using FintechSync.API.Domain;
using FintechSync.API.TransactionReceivers.Fireflyiii;

namespace FintechSync.API.Receivers.Fireflyiii
{
    public interface IFireflyiiiService
    {
        Task PostTransactionAsync(Transaction transaction);
        void SetConfiguration(FireflyiiiConfiguration configuration);
    }
}