using api.Models.Domain;
using api.Repositories.FilesForUpdate.Interface;
using Microsoft.EntityFrameworkCore;
using server.Database;
using System.Reflection;
using System;
using System.IO;
using System.Diagnostics;
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
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(@dllFile);
                        if (assembly != null)
                        {
                            var dllObject = new UpdateObject()
                            {
                                FileName = assembly.GetName().Name,
                                FileType = FileType.DLL,
                                FileVersion = assembly.GetName().Version.ToString(),
                                AssemblyType = AssemblyType.Regasm
                            };
                            Console.WriteLine(String.Format("NET DLL: {0} Added to collection successfuly!", dllObject.FileName));
                            await _dbMainContext.UpdateObjects.AddAsync(dllObject);
                            
                        }
                    }
                    catch (Exception)
                    {
                        if(FileVersionInfo.GetVersionInfo(dllFile).FileVersion != null)
                        {
                            var dllObject = new UpdateObject()
                            {
                                FileName = Path.GetFileName(dllFile),
                                FileType = FileType.DLL,
                                FileVersion = FileVersionInfo.GetVersionInfo(dllFile).FileVersion.ToString(),
                                AssemblyType = AssemblyType.Regsvr32
                            };
                            await _dbMainContext.UpdateObjects.AddAsync(dllObject);
                            Console.WriteLine(String.Format("VB6 DLL: {0} Added to collection successfuly!", dllObject.FileName));
                            
                        }
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
