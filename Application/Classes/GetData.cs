using Application.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return new SetupUpdate
                {
                    RepeatUpdateMinutes = Convert.ToInt16(res.repeatUpdateMinutes),
                    ClearDLLTableMinutes = Convert.ToInt16(res.clearDLLTableMinutes),
                    DLLServerPath = res.dllServerPath,
                    OtherServerPath = res.otherServerPath,
                };
            }
            return null;
        }
		catch (Exception)
		{

			throw;
		}
    }
}
