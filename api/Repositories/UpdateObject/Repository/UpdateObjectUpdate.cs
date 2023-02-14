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
    public async Task<bool> UpdateObjectAsync(string objectName, string objectVersion)
    {
        var object_ = await _dbMainContext.UpdateObjects.FirstOrDefaultAsync(s=>s.FileName == objectName && s.FileVersion != objectVersion);
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
    public async Task<bool> DisableObjectUpdateAsync()
    {
        try
        {
            var objects = await _dbMainContext.UpdateObjects.ToListAsync();
            foreach (var object_ in objects)
            {
                object_.UpdateFile = Models.Domain.UpdateFile.NO;
            }
            await _dbMainContext.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
