namespace FintechSync.API.Receivers
{
    public interface ITransactionReceiver
    {
        Task PostTransactionAsync(Domain.Transaction transaction);
    }
}
