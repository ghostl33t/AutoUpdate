using Microsoft.EntityFrameworkCore;
using serverService;
using serverService.Data;
using serverService.Repository;
using serverService.Services;



IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<DLLChecker>().AddSingleton<ISetupUpdate, serverService.Repository.SetupUpdate>();
        services.AddHostedService<DLLChecker>().AddSingleton<IDLLToDatabase, DLLToDatabase>();
    })
    .Build();

await host.RunAsync();