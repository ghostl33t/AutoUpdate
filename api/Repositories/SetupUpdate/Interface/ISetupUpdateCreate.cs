namespace api.Repositories.SetupUpdate.Interface;
public interface ISetupUpdateCreate
{
    public Task<bool> CreateSetupAsync(Models.Domain.SetupUpdate newSetupUpdate);
}
