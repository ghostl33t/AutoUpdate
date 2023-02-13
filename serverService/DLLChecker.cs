using serverService.Data;

namespace serverService;

public class DLLChecker : BackgroundService
{
    private readonly ILogger<DLLChecker> _logger;
    private readonly DBMainContext _dBContextMain;

    //TODO: Kreirati provjeru DLLova na svakih X minuta koje su definisane u konfiguraciji.
    //TODO: Kreirati poziv na API i taj API koji ce ukoliko ima potrebe azurirati polje za update u bazi

    public DLLChecker(ILogger<DLLChecker> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }
}