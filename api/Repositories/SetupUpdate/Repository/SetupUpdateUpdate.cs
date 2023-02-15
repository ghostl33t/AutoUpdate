using api.Repositories.SetupUpdate.Interface;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace api.Repositories.SetupUpdate.Repository;
public class SetupUpdateUpdate : ISetupUpdateUpdate
{
    private readonly DBMainContext _dbMainContext;
    public SetupUpdateUpdate(DBMainContext dbMainContext)
    {
        _dbMainContext = dbMainContext;
    }
    public async Task<bool> UpdateSetupAsync(Models.Domain.SetupUpdate setupUpdate)
    {
        try
        {
            if (setupUpdate != null)
            {
                var existingSetupUpdate = await _dbMainContext.SetupUpdate.FirstOrDefaultAsync(s => s.Id == setupUpdate.Id);
                if (existingSetupUpdate != null)
                {
                    existingSetupUpdate.DLLServerPath = setupUpdate.DLLServerPath;
                    existingSetupUpdate.OtherServerPath = setupUpdate.OtherServerPath;
                    existingSetupUpdate.RepeatUpdateMinutes = setupUpdate.RepeatUpdateMinutes;
                    existingSetupUpdate.ClearDLLTableMinutes = setupUpdate.ClearDLLTableMinutes;

                    _dbMainContext.Update(existingSetupUpdate);
                    await _dbMainContext.SaveChangesAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        catch (Exception)
        {

            throw;
        }
    }
}