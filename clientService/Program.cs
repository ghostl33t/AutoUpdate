using clientService;
using clientService.Repository;
using clientService.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<DLLUpdateAndRegistration>().AddSingleton<ISetupUpdate, clientService.Repository.SetupUpdate>();
        services.AddHostedService<DLLUpdateAndRegistration>().AddSingleton<IUpdateObject, clientService.Repository.UpdateObject>();
        services.AddHostedService<DLLUpdateAndRegistration>().AddSingleton<ICopyFiles, CopyFiles>();
        services.AddHostedService<DLLUpdateAndRegistration>().AddSingleton<IRegistration, Registration>();
    })
    .Build();

await host.RunAsync();
