using Application.Interfaces;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text;

namespace Application.Classes;
public class PatchData : IPatchData
{
    private readonly HttpClient _client;
    public PatchData()
    {
        _client = new HttpClient();
    }
    public async Task<bool> UpdateSetupAsync(SetupUpdate setupUpdate)
    {
        try
        {
            var content = new StringContent(JsonConvert.SerializeObject(setupUpdate), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _client.PatchAsync("http://localhost:5286/setup", content);
            if (response.IsSuccessStatusCode == true)
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
    public async Task<bool> UpdateSetupLocalAsync(SetupUpdateLocal setupLocal)
    {
        try
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey("Software\\VB and VBA Program Settings\\Imel-BIS Update\\Settings");
            key.SetValue("LokPath", setupLocal.DLLLocalPath);
            key.SetValue("LokPathOstali", setupLocal.OtherLocalPath);
            key.Close();
            return await Task.FromResult(true);
        }
        catch (Exception)
        {
            throw;
        }
    }
}
