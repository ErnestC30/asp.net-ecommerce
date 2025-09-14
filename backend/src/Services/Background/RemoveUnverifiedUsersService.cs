using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;

using backend.Models;

namespace backend.Services;

public class RemoveUnverifiedUsersService : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<RemoveUnverifiedUsersService> _logger;
    private string _taskName = "RemoveUnverifiedUsersService";
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(20);

    public RemoveUnverifiedUsersService(IServiceScopeFactory scopeFactory, ILogger<RemoveUnverifiedUsersService> logger)
    {
        _scopeFactory = scopeFactory;
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
        using var scope = _scopeFactory.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
        var currentTime = DateTime.UtcNow;
        var timeBeforeAccountIsAbandoned = currentTime - TimeSpan.FromDays(14);
        var usersForDelete = await userManager.Users.Where(u => !u.EmailConfirmed && u.RegistrationDate < timeBeforeAccountIsAbandoned).ToListAsync();
        foreach (var user in usersForDelete)
        {
            _logger.LogInformation($"Deleting User with Id: {user.Id}");
            var result = await userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                _logger.LogWarning($"Failed to delete user {user.Id}: {string.Join(", ", result.Errors.Select(e => e.Description))}");
            }
        }
    }
}