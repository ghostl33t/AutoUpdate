using Microsoft.EntityFrameworkCore;
using serverService.Data;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext,services) =>
    {
        services.AddDbContext<DBMainContext>(options =>
        {
            var mainConnectionString = hostContext.Configuration.GetConnectionString("DBConnection");
            if (mainConnectionString != null)
            {
                options.UseSqlServer(mainConnectionString);
            }
            else
            {
                Console.WriteLine("ERROR: Greska prilikom konektovanja na SQL server");
            }
        });
    })
    .Build();

host.Run();
