using Microsoft.Win32;
using Newtonsoft.Json;
using System.Runtime.Versioning;

namespace clientService.Repository;
public class SetupUpdate : ISetupUpdate
{
    private readonly HttpClient _client;
    public SetupUpdate()
	{
        _client = new HttpClient();
    }
    [SupportedOSPlatform("windows")]
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
                var key = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\Imel-BIS Update\\Settings");
                Data.SetupUpdate returnObject = new();
                if (res != null)
                {
                    returnObject = new()
                    {
                         Id = Convert.ToInt32(res.id),
                         RepeatUpdateMinutes = Convert.ToInt16(res.repeatUpdateMinutes),
                         ClearDLLTableMinutes = Convert.ToInt16(res.clearDLLTableMinutes),
                         DLLServerPath = res.dllServerPath,
                         OtherServerPath = res.otherServerPath
                    };
                }
                if(key is null)
                {
                    returnObject.DLLLocalPath = "";
                    returnObject.DLLLocalPath = "";
                }
                else
                {
                    var lokPath = key.GetValue("LokPath");
                    var lokPathOstali = key.GetValue("LokPathOstali");
                    //TODO Bolje handlirat ove warninge za null reference iz registrija 
                    if (lokPath is not null)
                    {
                        returnObject.DLLLocalPath = lokPath.ToString();
                    }
                    if (lokPathOstali != null)
                    {
                        returnObject.OtherLocalPath = lokPathOstali.ToString();
                    }
                }
                return returnObject;
            }
            return new Data.SetupUpdate();
        }
        catch (Exception)
        {
            throw;
        }
    }
}
