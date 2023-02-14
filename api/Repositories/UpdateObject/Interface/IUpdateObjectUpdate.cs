namespace api.Repositories.FilesForUpdate.Interface;
public interface IUpdateObjectUpdate
{
    public Task<bool> UpdateObjectAsync(string objectName, string objectVersion);
    public Task<bool> DisableObjectUpdateAsync();
}
