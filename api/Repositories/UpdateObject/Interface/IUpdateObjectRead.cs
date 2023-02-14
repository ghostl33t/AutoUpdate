using api.Models.DTO;

namespace api.Repositories.UpdateObject.Interface;
public interface IUpdateObjectRead
{
    public Task<List<UpdateObjectDTOGET>> GetDLLsForUpdate();
}
