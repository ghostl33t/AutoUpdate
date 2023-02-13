using api.Models.Domain;
using api.Repositories.FilesForUpdate.Interface;
using Microsoft.EntityFrameworkCore;
using server.Database;
using System.Reflection;

namespace api.Repositories.FilesForUpdate.Repository;
public class UpdateObjectCreate : IUpdateObjectCreate
{
    private readonly DBMainContext _dbMainContext;
    public UpdateObjectCreate(DBMainContext dbMainContext)
    {
        _dbMainContext = dbMainContext;
    }
    public async Task<bool> CreateListOfDLLsAsync()
    {
        try
        {
            var setup = await _dbMainContext.SetupUpdate.FirstOrDefaultAsync();
            if (setup != null)
            {
                string[] dllFiles = Directory.GetFiles(setup.DLLServerPath, "*.dll");
                foreach (string dllFile in dllFiles)
                {
                    Assembly assembly = Assembly.LoadFrom(dllFile);
                    if(assembly != null ) 
                    {
                        var dllObject = new UpdateObject()
                        {
                            FileName = assembly.GetName().Name,
                            FileType = FileType.DLL,
                            FileVersion = assembly.GetName().Version.ToString()
                        };
                        if(assembly.CodeBase == "test")
                        {
                            dllObject.AssemblyType = AssemblyType.Regsvr32;
                        }
                        await _dbMainContext.UpdateObjects.AddAsync(dllObject);
                    }
                }
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
