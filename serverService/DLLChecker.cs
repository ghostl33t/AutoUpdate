using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using serverService.Data;
using serverService.Repository;
using System.Diagnostics;
using System.Text;

namespace serverService;

public class DLLChecker : BackgroundService
{
    private readonly ISetupUpdate _setupUpdateRepo;
    private static readonly HttpClient client = new HttpClient();
    //TODO: Kreirati provjeru DLLova na svakih X minuta koje su definisane u konfiguraciji.
    //TODO: Kreirati poziv na API i taj API koji ce ukoliko ima potrebe azurirati polje za update u bazi

    public DLLChecker( ISetupUpdate setupUpdateRepo)
    {
        _setupUpdateRepo = setupUpdateRepo;
    }

    public async Task<bool> WriteDLLsToDatabase(Data.SetupUpdate setupUpdate)
    {
        if (setupUpdate != null)
        {
            if (setupUpdate.DLLServerPath != "")
            {
                try
                {
                    client.Timeout = TimeSpan.FromMinutes(10);
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5286/object-check", null);
                    
                    response.EnsureSuccessStatusCode();
                    Console.WriteLine("Request sent successfully.");
                    RegistryKey keySave = Registry.CurrentUser.CreateSubKey("Software\\VB and VBA Program Settings\\AutoUpdate");
                    keySave.SetValue("AutoUpdate", "1");
                    keySave.Close();
                    return await Task.FromResult(true);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        return await Task.FromResult(false);
    }
    public async Task<bool> ValidateObjectForUpdate(Data.SetupUpdate setupUpdate)
    {
        if (setupUpdate != null)
        {
            if (setupUpdate.DLLServerPath != "")
            {
                string[] dllFiles = Directory.GetFiles(setupUpdate.DLLServerPath, "*.dll");
                client.Timeout = TimeSpan.FromMinutes(10);
                foreach (string dllFile in dllFiles)
                {
                    try
                    {
                        if(FileVersionInfo.GetVersionInfo(dllFile).FileVersion != null)
                        {
                            var objectToCheck = new
                            {
                                FileName = Path.GetFileName(dllFile),
                                FileVersion = FileVersionInfo.GetVersionInfo(dllFile).FileVersion
                            };
                            var content = new StringContent(JsonConvert.SerializeObject(objectToCheck), Encoding.UTF8, "application/json");
                            HttpResponseMessage response = await client.PatchAsync("http://localhost:5286/object-check", content);

                            response.EnsureSuccessStatusCode();
                            //TODO ako je request izvrsen, tada ispisati poruku da je dll za update ili nije
                            Console.WriteLine(Path.GetFileName(dllFile));
                            
                        }
                        
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        return await Task.FromResult(true);
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var setupUpdate = await _setupUpdateRepo.GetSetupAsync();
        //Upisi sve DLLove u bazu
        RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\AutoUpdate");
        if (key != null)
        {
            if (key.GetValue("AutoUpdate").ToString() != "1")
            {
                await WriteDLLsToDatabase(setupUpdate);
            }
        }
        else
        {
            await WriteDLLsToDatabase(setupUpdate);
        }

        //TODO: Validiraj fajlove na svakih RepeatUpdateMinutes na osnovu putanje DLLServerPath

        if (setupUpdate != null)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //TODO: Ako je verzija DLLa na putanji razlicita od one u bazi pozovi API 
                await ValidateObjectForUpdate(setupUpdate);

                await Task.Delay(setupUpdate.RepeatUpdateMinutes * 1000, stoppingToken);
            }
        }
    }
}