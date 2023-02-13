using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
