using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text;

namespace Application.Classes;

internal class PostData
{
    private static readonly HttpClient client = new HttpClient();
    public async Task<bool> CreateSetupAsync(SetupUpdate newSetup)
    {
        try
        {
            var content = new StringContent(JsonConvert.SerializeObject(newSetup), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync("http://localhost:5000/setup", content);
            response.EnsureSuccessStatusCode();
            Console.WriteLine("Request sent successfully.");
            return true;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public  Task<bool> CreateSetupLocalAsync(SetupUpdateLocal newSetupLocal)
    {
        try
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\VB and VBA Program Settings\\Imel-BIS Update\\Settings"); 
            key.SetValue("LokPath", newSetupLocal.DLLLocalPath);
            key.SetValue("LokPathOstali", newSetupLocal.OtherLocalPath);
            key.Close();
            return Task.FromResult(true);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
