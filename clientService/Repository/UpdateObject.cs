﻿using Newtonsoft.Json;
namespace clientService.Repository;
public class UpdateObject : IUpdateObject
{
    private readonly HttpClient _client;
    public UpdateObject()
    {
        _client = new HttpClient();
    }
    public async Task<List<Data.UpdateObject>> GetObjectsForUpdateAsync()
    {
        try
        {
            var response = await _client.GetAsync("http://localhost:5286/object-check");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            if (responseBody != null)
            {
                dynamic res = JsonConvert.DeserializeObject(responseBody);
                List<Data.UpdateObject> dllsForUpdate = new List<Data.UpdateObject>();
                
                if (res != null)
                {
                    foreach (var row in res)
                    {
                        Data.UpdateObject objForUpdate = new()
                        {
                            FileName = row.fileName,
                            FileVersion = row.fileVersion,
                            AssemblyType = row.assemblyType
                        };
                        dllsForUpdate.Add(objForUpdate);
                    }
                }
                return await Task.FromResult( dllsForUpdate);
            }
            return null;
        }
        catch (Exception)
        {

            throw;
        }
    }
}
