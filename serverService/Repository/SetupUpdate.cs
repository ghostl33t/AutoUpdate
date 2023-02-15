using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using serverService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverService.Repository;
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
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                if (responseBody != null)
                {
                    dynamic res = JsonConvert.DeserializeObject(responseBody);
                    if (res != null)
                    {
                        return new Data.SetupUpdate
                        {
                            Id = Convert.ToInt32(res.id),
                            RepeatUpdateMinutes = Convert.ToInt16(res.repeatUpdateMinutes),
                            ClearDLLTableMinutes = Convert.ToInt16(res.clearDLLTableMinutes),
                            DLLServerPath = res.dllServerPath,
                            OtherServerPath = res.otherServerPath,
                        };
                    }
                }
            }
            return new Data.SetupUpdate();
        }
        catch (Exception)
        {

            throw;
        }
    }
}
