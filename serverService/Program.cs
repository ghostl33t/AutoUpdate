using Microsoft.EntityFrameworkCore;
using serverService;
using serverService.Data;
using serverService.Repository;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<DLLChecker>().AddSingleton<ISetupUpdate, serverService.Repository.SetupUpdate>();
    })
    .Build();

await host.RunAsync();