// See https://aka.ms/new-console-template for more information
using FintechSync.API.Receivers.Fireflyiii;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

Console.WriteLine("Hello, World!");

using IHost host = CreateHostBuilder(args).Build();

await ExemplifyScoping(host.Services);

await host.RunAsync();

static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
            services
            .AddTransient< IFireflyiiiService, FireflyiiiService>()
            .AddHttpClient<IFireflyiiiApiClient, FireflyiiiApiClient>());

static async Task ExemplifyScoping(IServiceProvider services)
{
    using IServiceScope serviceScope = services.CreateScope();
    IServiceProvider provider = serviceScope.ServiceProvider;

    var fireflyiiiService = provider.GetRequiredService<IFireflyiiiService>();

    fireflyiiiService.SetConfiguration(new FintechSync.API.TransactionReceivers.Fireflyiii.FireflyiiiConfiguration
    {
        BaseAddress = "https://firefly.benscobie.com",
        AccessToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiJ9.eyJhdWQiOiIxMSIsImp0aSI6IjNlMjZhYmQwMzA3YjY2NGJhNDhhMmM1OGM4NzFjYzEyZGZlNGM2ZTMyOTM3MjVkM2QxODllNmVhOTIzYzcxY2VlNzJhNTlmNDE4YmE5Zjg5IiwiaWF0IjoxNjM3MDEwMzg3LjQ0NjA0NywibmJmIjoxNjM3MDEwMzg3LjQ0NjA1NCwiZXhwIjoxNjY4NTQ2Mzg3LjMyOTY3OSwic3ViIjoiMSIsInNjb3BlcyI6W119.Z9t3qh4J5-xzHSQbmAECOh9btW4ugcTcPGsHO4zYKs4mf3mFyPUT83GfQeizLRYrghgF-UI7-eikI2Kmgh469jBjzcWuRc8pSa8PXzBMDTQoxiusPBeZdYaH-IZt0t1MBbFK4KfKmn1n1-cWTGyIwDA8nHIKTZNEmEl0Oe5OBe3sJoqhu21mqp_YiGaUrCGLzT9FYqtjj8L8xGbSrDF9z1l60DiWbcOfJ1wd37rPytrvv7PWk9Y5sa8LDYe4JZFKW9Nitx6yPX1sYjF3SDM8v90vZsAhAP7-IrKKlZnyAoEGl5VuoKghS-P4fJsfzj7ZRMCKHCvrcKH1geN6n9Fel26ZE87g8oP8YwgIKYkyshsLCSarm2eMMn94QcP9zZ-7M5vn4cq2xVv8ABlEwkad5w2TlfEB1z5N1alhwlpJ4EBAaf9sThm4aj55boxiLCd5hSeJN-BKLeVe1rymvT3TKL6ryw6xxtF2ch2SSZ9PazY-fmgsZEiPyEMTVhOHKxTlBr59js4qHH-ISdFVlWk0Vwm9VL-hJGady-7Rzxwez_sWqKzqnEADZ7g5gHoXzZ67Mimn1n2E44rvB7jFrpYMGtMA5XIXNaam4-Sdtby6W7E699aR3CxzTfzhvjh5FeuiAogD3e4SpnTVGNUHNAqMRWzRjPFoY3n2vrUSfDqYcjQ",
        SourceAccountId = 1
    });

    await fireflyiiiService.PostTransactionAsync(new FintechSync.API.Domain.Transaction
    {
        Amount = -100,
        Created = DateTimeOffset.Now,
        Currency = "GBP",
        Description = "#car",
        Merchant = "Airbnb",
        Settled = DateTimeOffset.Now,
        TransactionSender = FintechSync.API.Domain.TransactionSender.Monzo,
    });


    Console.WriteLine();
}