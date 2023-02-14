using api.Models.Domain;
using api.Models.DTO;
using api.Repositories.UpdateObject.Interface;
using Microsoft.EntityFrameworkCore;
using server.Database;


namespace api.Repositories.UpdateObject.Repository;
public class UpdateObjectRead : IUpdateObjectRead
{
    private readonly DBMainContext _dbMainContext;
    public UpdateObjectRead(DBMainContext dbMainContext)
    {
        _dbMainContext = dbMainContext;
    }
    public async Task<List<UpdateObjectDTOGET>> GetDLLsForUpdate()
    {
        try
        {
            var objectsForUpdate = await _dbMainContext.UpdateObjects.Where(s => s.UpdateFile == UpdateFile.YES).ToListAsync();
            List<UpdateObjectDTOGET> updateobjects = new();
            foreach(var object_ in objectsForUpdate) 
            {
                UpdateObjectDTOGET obj = new()
                {
                    FileName = object_.FileName,
                    FileVersion = object_.FileVersion,
                    AssemblyType = object_.AssemblyType
                };
                updateobjects.Add(obj);
            }
            return updateobjects;
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
