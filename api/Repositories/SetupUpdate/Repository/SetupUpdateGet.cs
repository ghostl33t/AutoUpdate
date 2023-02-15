using api.Repositories.SetupUpdate.Interface;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace api.Repositories.SetupUpdate.Repository;

public class SetupUpdateGet : ISetupUpdateGet
{
    private readonly DBMainContext _dbMainContext;
    public SetupUpdateGet(DBMainContext dbMainContext)
    {
        _dbMainContext = dbMainContext;
    }
    public async Task<Models.Domain.SetupUpdate> GetSetupAsync()
    {
		try
		{
            return await _dbMainContext.SetupUpdate.FirstAsync();
		}
		catch (Exception)
		{

			throw;
		}
    }
}
