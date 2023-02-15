namespace Application.Interfaces;
public interface IPatchData
{
    public  Task<bool> UpdateSetupAsync(SetupUpdate setupUpdate);
    public Task<bool> UpdateSetupLocalAsync(SetupUpdateLocal setupLocal);
}
