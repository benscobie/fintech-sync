using FintechSync.API.Receivers.Fireflyiii.Dtos.Transactions;
using FintechSync.API.TransactionReceivers.Fireflyiii;
using FintechSync.API.TransactionReceivers.Fireflyiii.Dtos.Autocomplete;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace FintechSync.API.Receivers.Fireflyiii
{
    public class FireflyiiiApiClient : IFireflyiiiApiClient
    {
        private readonly HttpClient _httpClient;

        public FireflyiiiApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetConfiguration(FireflyiiiConfiguration configuration)
        {
            _httpClient.BaseAddress = new Uri(configuration.BaseAddress);
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", configuration.AccessToken);
        }

        public async Task NewTransactionAsync(RootTransaction transaction)
        {
            var transactionJson = new StringContent(JsonSerializer.Serialize(transaction), Encoding.UTF8, Application.Json);

            var theJson = await transactionJson.ReadAsStringAsync();

            using var httpResponseMessage = await _httpClient.PostAsync("/api/v1/transactions", transactionJson);

            var result = await httpResponseMessage.Content.ReadAsStringAsync();

            httpResponseMessage.EnsureSuccessStatusCode();
        }

        public async Task<List<Account>> SearchAccountsAsync(string searchTerm, string type)
        {
            var query = new Dictionary<string, string>
            {
                ["query"] = searchTerm,
                ["limit"] = "10",
                ["type"] = type,
            };

            return await _httpClient.GetFromJsonAsync<List<Account>>(QueryHelpers.AddQueryString("/api/v1/autocomplete/accounts", query));
        }
    }
}
