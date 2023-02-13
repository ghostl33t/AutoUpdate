using api.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace server.Database;
public class DBMainContext : DbContext
{
    public DBMainContext(DbContextOptions<DBMainContext> options) : base(options)
    {

    }
    public DbSet<SetupUpdate> SetupUpdate { get; set; }
    public DbSet<UpdateObject> UpdateObjects { get; set; }
}
