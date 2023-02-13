namespace api.Repositories.SetupUpdate.Interface;

public interface ISetupUpdateGet
{
    public Task<Models.Domain.SetupUpdate> GetSetupAsync();
}
