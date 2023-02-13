namespace Application.Interfaces;
internal interface IGetData
{
    public Task<SetupUpdate> GetSetupAsync();
}
