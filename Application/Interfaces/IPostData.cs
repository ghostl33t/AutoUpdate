namespace Application.Interfaces;

internal interface IPostData
{
    public Task<bool> CreateSetupAsync(SetupUpdate newSetup);
}
