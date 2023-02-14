using clientService;
using clientService.Repository;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<DLLUpdateAndRegistration>().AddSingleton<ISetupUpdate, clientService.Repository.SetupUpdate>();
        services.AddHostedService<DLLUpdateAndRegistration>().AddSingleton<IUpdateObject, clientService.Repository.UpdateObject>();
    })
    .Build();

await host.RunAsync();
