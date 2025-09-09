using Microsoft.Extensions.Hosting;

namespace backend.Services;

public class RemoveUnverifiedUsersService : BackgroundService
{

    private readonly ILogger<RemoveUnverifiedUsersService> _logger;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);
    private string _taskName = "RemoveUnverifiedUsersService";

    public RemoveUnverifiedUsersService(ILogger<RemoveUnverifiedUsersService> logger)
    {
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation($"Starting Background Task: {_taskName}");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation($"Running Task: {_taskName}");
                await DeleteUnverifiedUsers();
                await Task.Delay(_interval, stoppingToken);
            }
            catch (TaskCanceledException)
            {

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Task");
            }
        }

        _logger.LogInformation($"Stopping Background Task: {_taskName}");
    }

    private async Task DeleteUnverifiedUsers()
    {
        _logger.LogInformation("Deleting Users...");
    }
}