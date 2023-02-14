using api.Repositories.FilesForUpdate.Interface;
using Microsoft.EntityFrameworkCore;
using server.Database;

namespace api.Repositories.FilesForUpdate.Repository;
public class UpdateObjectUpdate : IUpdateObjectUpdate
{
    private readonly DBMainContext _dbMainContext;
    public UpdateObjectUpdate(DBMainContext dbMainContext)
    {
        _dbMainContext = dbMainContext;
    }
    public async Task<bool> UpdateObjectAsync(string objectName)
    {
        var object_ = await _dbMainContext.UpdateObjects.FirstOrDefaultAsync(s=>s.FileName == objectName);
        try
        {
            if(object_ != null) 
            {
                object_.UpdateFile = Models.Domain.UpdateFile.YES;
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
