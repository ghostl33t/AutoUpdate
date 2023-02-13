namespace api.Repositories.SetupUpdate.Interface;
public interface ISetupUpdateUpdate
{
    public  Task<bool> CreateSetupAsync(Models.Domain.SetupUpdate setupUpdate);
}
