namespace api.Repositories.SetupUpdate.Interface;
public interface ISetupUpdateUpdate
{
    public  Task<bool> UpdateSetupAsync(Models.Domain.SetupUpdate setupUpdate);
}
