using api.Repositories.SetupUpdate.Interface;
using server.Database;

namespace api.Repositories.SetupUpdate.Repository;
public class SetupUpdateCreate : ISetupUpdateCreate
{
    private readonly DBMainContext _dbMainContext;
    public SetupUpdateCreate(DBMainContext dbMainContext)
    {
        _dbMainContext = dbMainContext;
    }
    public async Task<bool> CreateSetupAsync(Models.Domain.SetupUpdate newSetupUpdate)
    {
        try
        {
            if(newSetupUpdate != null)
            {
                await _dbMainContext.SetupUpdate.AddAsync(newSetupUpdate);
                await _dbMainContext.SaveChangesAsync();    
                return true;
            }
            return false;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
