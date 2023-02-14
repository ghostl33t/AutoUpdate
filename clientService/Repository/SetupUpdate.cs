using Microsoft.Win32;
using Newtonsoft.Json;
namespace clientService.Repository;
public class SetupUpdate : ISetupUpdate
{
    private readonly HttpClient _client;
    public SetupUpdate()
	{
        _client = new HttpClient();
    }
    public async Task<Data.SetupUpdate> GetSetupAsync()
    {
        try
        {
            var response = await _client.GetAsync("http://localhost:5286/setup");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody != null)
            {
                dynamic res = JsonConvert.DeserializeObject(responseBody);
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\Imel-BIS Update\\Settings");
                if (res != null && key != null)
                {
                    return new Data.SetupUpdate
                    {
                        Id = Convert.ToInt32(res.id),
                        RepeatUpdateMinutes = Convert.ToInt16(res.repeatUpdateMinutes),
                        ClearDLLTableMinutes = Convert.ToInt16(res.clearDLLTableMinutes),
                        DLLServerPath = res.dllServerPath,
                        OtherServerPath = res.otherServerPath,
                        DLLLocalPath= key.GetValue("LokPath").ToString(),
                        OtherLocalPath = key.GetValue("LokPathOstali").ToString(),
                    };
                }
            }
            return null;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
