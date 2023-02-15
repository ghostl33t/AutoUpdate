using clientService.Repository;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace clientService.Services;
public class CopyFiles : ICopyFiles
{
    private readonly IUpdateObject _updateObjectRepo;
    private readonly IRegistration _registration;
    public CopyFiles(IUpdateObject updateObjectRepo, IRegistration registration)
    {
        _updateObjectRepo= updateObjectRepo;
        _registration= registration;
    }
    //TODO ova metoda moze vratiti listu dllova i informaciju da li su uspjesno updateani / registrovani
    //TODO Mozda bolje rastaviti ove validacije na prostije metode da se olaksa citljivost ???
    public async Task<bool> UpdateDLLToSystem(Data.SetupUpdate setupUpdate)
    {
        var dllForUpdate = await _updateObjectRepo.GetObjectsForUpdateAsync();
        foreach (var dll in dllForUpdate)
        {
            if(dll.FileName == "AlphaGasVrstaBoca.dll")
            {
                Console.WriteLine("tu");
            }
            if (!File.Exists(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName)))
            {
                try
                {
                    if(File.Exists(Path.Combine(setupUpdate.DLLServerPath, dll.FileName)))
                    {
                        System.IO.File.Copy(Path.Combine(setupUpdate.DLLServerPath, dll.FileName), Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                        if (dll.AssemblyType == Data.AssemblyType.Regasm)
                        {
                            var stpPath = setupUpdate.DLLLocalPath;
                            stpPath = string.Format("\"{0}\"", stpPath);
                            await _registration.RegisterNETDLL(Path.Combine(stpPath, dll.FileName));
                        }
                        else if (dll.AssemblyType == Data.AssemblyType.Regsvr32)
                        {
                            await _registration.RegisterVBDLL(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
               
            }
            else if(File.Exists(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName)))
            {
                try
                {
                    var fileVersion = FileVersionInfo.GetVersionInfo(setupUpdate.DLLLocalPath + @"\" + dll.FileName).FileVersion;
                    if (fileVersion != null)
                    {
                        if (dll.FileVersion != fileVersion.ToString())
                        {

                            System.IO.File.Delete(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                            if (File.Exists(Path.Combine(setupUpdate.DLLServerPath, dll.FileName)))
                            {
                                System.IO.File.Copy(Path.Combine(setupUpdate.DLLServerPath, dll.FileName), Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                                if (dll.AssemblyType == Data.AssemblyType.Regasm)
                                {
                                    var stpPath = setupUpdate.DLLLocalPath;
                                    stpPath = string.Format("\"{0}\"", stpPath);
                                    await _registration.RegisterNETDLL(Path.Combine(stpPath, dll.FileName));
                                }
                                else if (dll.AssemblyType == Data.AssemblyType.Regsvr32)
                                {
                                    await _registration.RegisterVBDLL(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                    throw;
                }
                
            }

        }
        Console.WriteLine("Update završen!");
        return await Task.FromResult(true);
    }
}
