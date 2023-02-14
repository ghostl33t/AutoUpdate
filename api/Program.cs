using api.Repositories.FilesForUpdate.Interface;
using api.Repositories.FilesForUpdate.Repository;
using api.Repositories.SetupUpdate.Interface;
using api.Repositories.SetupUpdate.Repository;
using Microsoft.EntityFrameworkCore;
using server.Database;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

/* DbConnection */
builder.Services.AddDbContext<DBMainContext>(options =>
{
    var mainConnectionString = builder.Configuration.GetConnectionString("DBConnection");
    if (mainConnectionString != null)
    {
        options.UseSqlServer(mainConnectionString);
    }
    else
    {
        Console.WriteLine("ERROR: Greska prilikom konektovanja na SQL server!");
    }
});

builder.Services.AddScoped<ISetupUpdateCreate, SetupUpdateCreate>();
builder.Services.AddScoped<ISetupUpdateGet, SetupUpdateGet>();

builder.Services.AddScoped<IUpdateObjectCreate, UpdateObjectCreate>();
builder.Services.AddScoped<IUpdateObjectUpdate, UpdateObjectUpdate>();

var app = builder.Build();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
