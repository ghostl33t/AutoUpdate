using Application.Interfaces;
using Microsoft.Win32;
using Newtonsoft.Json;


namespace Application.Classes;
internal class GetData : IGetData
{
    private static readonly HttpClient client = new HttpClient();
    public async Task<SetupUpdate> GetSetupAsync()
    {
		try
		{
            var response = await client.GetAsync("http://localhost:5000/setup");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody != null)
            {
                dynamic res = JsonConvert.DeserializeObject(responseBody);
                if (res != null)
                {
                    return new SetupUpdate
                    {
                        Id = Convert.ToInt32(res.id),
                        RepeatUpdateMinutes = Convert.ToInt16(res.repeatUpdateMinutes),
                        ClearDLLTableMinutes = Convert.ToInt16(res.clearDLLTableMinutes),
                        DLLServerPath = res.dllServerPath,
                        OtherServerPath = res.otherServerPath,
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

    public  Task<SetupUpdateLocal> GetSetupLocalAsync()
    {
        try
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\VB and VBA Program Settings\\Imel-BIS Update\\Settings");
            if (key != null)
            {
                return Task.FromResult(new SetupUpdateLocal
                {
                    DLLLocalPath = key.GetValue("LokPath").ToString(),
                    OtherLocalPath = key.GetValue("LokPathOstali").ToString(),
                });
            }
            return Task.FromResult(new SetupUpdateLocal());
        }
        catch (Exception)
        {

            throw;
        }
        
    }
}
