using clientService.Repository;
using clientService.Services;

namespace clientService;

public class DLLUpdateAndRegistration : BackgroundService
{
    private readonly ISetupUpdate _setupUpdateRepo;
    private readonly ICopyFiles _copyFiles;
    public DLLUpdateAndRegistration(ISetupUpdate setupUpdateRepo, ICopyFiles copyFiles)
    {
        _setupUpdateRepo = setupUpdateRepo;
        _copyFiles = copyFiles;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var setupUpdate = await _setupUpdateRepo.GetSetupAsync();

        if (setupUpdate != null)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _copyFiles.UpdateDLLToSystem(setupUpdate);
                await Task.Delay(setupUpdate.RepeatUpdateMinutes * 1000, stoppingToken);
            }
        }
    }
}