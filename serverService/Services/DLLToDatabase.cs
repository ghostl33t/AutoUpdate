using Microsoft.Win32;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;


namespace serverService.Services;
public class DLLToDatabase : IDLLToDatabase
{
    private readonly HttpClient _client;
    public DLLToDatabase()
    {
        _client = new HttpClient();
    }
    public async Task<bool> WriteDLLsToDatabase(Data.SetupUpdate setupUpdate)
    {
        if (setupUpdate != null)
        {
            if (setupUpdate.DLLServerPath != "")
            {
                try
                {
                    _client.Timeout = TimeSpan.FromMinutes(10);
                    HttpResponseMessage response = await _client.PostAsync("http://localhost:5286/object-check", null);

                    response.EnsureSuccessStatusCode();
                    Console.WriteLine("Request sent successfully.");
                    if (OperatingSystem.IsWindows())
                    {
                        RegistryKey keySave = Registry.CurrentUser.CreateSubKey("Software\\VB and VBA Program Settings\\AutoUpdate");
                        keySave.SetValue("AutoUpdate", "1");
                        keySave.Close();
                    }
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
                _client.Timeout = TimeSpan.FromMinutes(10);
                foreach (string dllFile in dllFiles)
                {
                    try
                    {
                        if (FileVersionInfo.GetVersionInfo(dllFile).FileVersion != null)
                        {
                            var objectToCheck = new
                            {
                                FileName = Path.GetFileName(dllFile),
                                FileVersion = FileVersionInfo.GetVersionInfo(dllFile).FileVersion
                            };
                            var content = new StringContent(JsonConvert.SerializeObject(objectToCheck), Encoding.UTF8, "application/json");
                            HttpResponseMessage response = await _client.PatchAsync("http://localhost:5286/object-check", content);
                            if(response.IsSuccessStatusCode == true)
                            {
                                Console.WriteLine("DLL: "+Path.GetFileName(dllFile) + " dodan u update!");
                            }
                            else
                            {
                                Console.WriteLine("DLL: " + Path.GetFileName(dllFile) + " nije dodan u update!");
                            }
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
}
