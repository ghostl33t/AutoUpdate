using clientService.Repository;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;

namespace clientService;

public class DLLUpdateAndRegistration : BackgroundService
{
    private readonly ISetupUpdate _setupUpdateRepo;
    private readonly IUpdateObject _updateObjectRepo;

    public DLLUpdateAndRegistration(ISetupUpdate setupUpdateRepo, IUpdateObject updateObjectRepo)
    {
        _setupUpdateRepo = setupUpdateRepo;
        _updateObjectRepo = updateObjectRepo;   
    }

    public async Task<bool> UpdateDLLToSystem(Data.SetupUpdate setupUpdate)
    {
        var dllForUpdate = await _updateObjectRepo.GetObjectsForUpdateAsync();
        foreach(var dll in dllForUpdate)
        {
            if(!File.Exists(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName)))
            {
                System.IO.File.Copy(Path.Combine(setupUpdate.DLLServerPath, dll.FileName), Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                if (dll.AssemblyType == Data.AssemblyType.Regasm)
                {
                    await RegisterNETDLL(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                }
                else if (dll.AssemblyType == Data.AssemblyType.Regsvr32)
                {
                    await RegisterVBDLL(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                }
            }
            else
            {
                if (dll.FileVersion != FileVersionInfo.GetVersionInfo(setupUpdate.DLLLocalPath + @"\" + dll.FileName).FileVersion.ToString())
                {
                    System.IO.File.Delete(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                    System.IO.File.Copy(Path.Combine(setupUpdate.DLLServerPath, dll.FileName), Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                    if (dll.AssemblyType == Data.AssemblyType.Regasm)
                    {
                        await RegisterNETDLL(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                    }
                    else if (dll.AssemblyType == Data.AssemblyType.Regsvr32)
                    {
                        await RegisterVBDLL(Path.Combine(setupUpdate.DLLLocalPath, dll.FileName));
                    }
                }
            }
            
        }
        return await Task.FromResult(true);

    }
    public async Task<bool> RegisterNETDLL(string dllPath)
    {
        try
        {
            //Assembly asm = Assembly.LoadFile(@"c:\temp\ImageConverter.dll");
            //RegistrationServices regAsm = new RegistrationServices();
            //bool bResult = regAsm.RegisterAssembly(asm, AssemblyRegistrationFlags.SetCodeBase);
            Process regasm = new Process();
            regasm.StartInfo.FileName = "regasm";
            regasm.StartInfo.Arguments = $"/tlb {dllPath}";
            regasm.StartInfo.UseShellExecute = false;
            regasm.StartInfo.RedirectStandardOutput = true;
            regasm.Start();
            regasm.WaitForExit();
            Console.WriteLine(".NET DLL: " + dllPath + " registered successfuly");
            return await Task.FromResult(true);
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<bool> RegisterVBDLL(string dllPath)
    {
        try
        {
            Process regsvr32 = new Process();
            regsvr32.StartInfo.FileName = "regsvr32.exe";
            regsvr32.StartInfo.Arguments = $"/s {dllPath}";
            regsvr32.StartInfo.UseShellExecute = false;
            regsvr32.StartInfo.RedirectStandardOutput = true;
            regsvr32.Start();
            regsvr32.WaitForExit();
            Console.WriteLine("VB6 DLL: " + dllPath + " registered successfuly");
            return await Task.FromResult(true);
        }
        catch (Exception)
        {

            throw;
        }
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var setupUpdate = await _setupUpdateRepo.GetSetupAsync();

        if (setupUpdate != null)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await UpdateDLLToSystem(setupUpdate);
                await Task.Delay(setupUpdate.RepeatUpdateMinutes * 1000, stoppingToken);
            }
        }
    }
}