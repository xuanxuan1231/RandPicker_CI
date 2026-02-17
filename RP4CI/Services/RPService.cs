using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Shared;
using dotnetCampus.Ipc.CompilerServices.GeneratedProxies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RP4CI.Services.NotificationProviders;
using RP4CI.Interface.Models;
using RP4CI.Interface.Services;

namespace RP4CI.Services;

public class RPService : IRPService
{
    public IIpcService IpcService { get; }
    private RPNotificationProvider RPNotificationProvider { get; }
        = IAppHost.Host!.Services.GetServices<IHostedService>().OfType<RPNotificationProvider>().Single();
    private ILogger<RPService> _logger;

    public RPService(IIpcService ipcService)
    {
        IpcService = ipcService;
        IpcService.IpcProvider.CreateIpcJoint<IRPService>(this);
        
        _logger = IAppHost.GetService<ILogger<RPService>>();
    }

    public void Notify(NotifyResult result)
    {
        RPNotificationProvider.ShowResult(result);
        _logger.LogInformation("接收到 RandPicker 对等端发来通知。");
    }

    public string PingService()
    {
        return "Pong";
    }
}