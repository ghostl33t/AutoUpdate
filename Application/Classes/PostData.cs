using Microsoft.VisualBasic;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text;

namespace Application.Classes;

internal class PostData
{
    private  readonly HttpClient _client;
    public PostData()
    {
        _client = new HttpClient();
    }
    public async Task<bool> CreateSetupAsync(SetupUpdate newSetup)
    {
        try
        {
            var content = new StringContent(JsonConvert.SerializeObject(newSetup), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PostAsync("http://localhost:5286/setup", content);
            if(response.IsSuccessStatusCode == true)
            {
                MessageBox.Show("Podešenja uspješno sačuvana!");
                return true;
            }
            else
            {
                Console.WriteLine("Podešenja nisu sačuvana.");
                return false;
            }
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
