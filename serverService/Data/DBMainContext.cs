using Microsoft.EntityFrameworkCore;

namespace serverService.Data;
public class DBMainContext : DbContext
{
    public DBMainContext(DbContextOptions<DBMainContext> options) : base(options)
    {

    }
}
