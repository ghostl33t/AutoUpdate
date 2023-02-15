namespace clientService.Services;
public interface ICopyFiles
{
    public Task<bool> UpdateDLLToSystem(Data.SetupUpdate setupUpdate);
}
