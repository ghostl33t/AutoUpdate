namespace clientService.Services;
public interface IRegistration
{
    public  Task<bool> RegisterNETDLL(string dllPath);
    public  Task<bool> RegisterVBDLL(string dllPath);
}
