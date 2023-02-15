using Microsoft.Win32;
using serverService.Repository;
using serverService.Services;
using System.Runtime.Versioning;

namespace serverService;

public class DLLChecker : BackgroundService
{
    private readonly ISetupUpdate _setupUpdateRepo;
    private readonly IDLLToDatabase _dllToDatabase;

    public DLLChecker(ISetupUpdate setupUpdateRepo, IDLLToDatabase dllToDatabase)
    {
        _setupUpdateRepo = setupUpdateRepo;
        _dllToDatabase = dllToDatabase;
    }
    [SupportedOSPlatform("windows")]
    private static async Task<bool> CheckRegistry()
    {
        if (Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\AutoUpdate") != null)
        {
             var key = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\AutoUpdate");
             if (key != null)
             {
                 if (key.GetValue("AutoUpdate") == null)
                 {
                     return await Task.FromResult(false);
                 }
                 else if (key.GetValue("AutoUpdate") != null)
                 {
                    var autoUpdate = key.GetValue("AutoUpdate");
                    if(autoUpdate != null)
                    {
                        if (autoUpdate.ToString() != "1")
                        {
                            return await Task.FromResult(false);
                        }
                    }
                     
                 }
             }
             else
             {
                 return await Task.FromResult(false);
             }
        }
        else
        {
            return await Task.FromResult(false);
        }
        
        return await Task.FromResult(true);
    }
    [SupportedOSPlatform("windows")]
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var setupUpdate = await _setupUpdateRepo.GetSetupAsync();

        //Upisi sve DLLove u bazu ako nisu upisani! - provjera na osnovu registrija
        if (await CheckRegistry() == false)
        {
            await _dllToDatabase.WriteDLLsToDatabase(setupUpdate);
        }
        //Validiraj DLlove iz sistema i iz baze te uradit prepis!
        if (setupUpdate != null)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _dllToDatabase.ValidateObjectForUpdate(setupUpdate);
                await Task.Delay(setupUpdate.RepeatUpdateMinutes * 1000, stoppingToken);
            }
        }
    }
}