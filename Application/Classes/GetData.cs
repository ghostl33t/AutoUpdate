using Application.Interfaces;
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
}
