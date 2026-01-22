

using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Shared;
using dotnetCampus.Ipc.CompilerServices.GeneratedProxies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RP4CI.Services.NotificationProviders;
using RP4CI.Shared.Models;
using RP4CI.Shared.Services;


namespace RP4CI.Services;

public class RPService : IRPService
{
    private IIpcService IpcService { get; }
    public RPNotificationProvider RPNotificationProvider { get; }
        = IAppHost.Host!.Services.GetServices<IHostedService>().OfType<RPNotificationProvider>().Single();

    public RPService(IIpcService ipcService)
    {
        IpcService = ipcService;
        IpcService.IpcProvider.CreateIpcJoint<IRPService>(this);
    }

    public void Notify(NotifyResult result)
    {
        RPNotificationProvider.ShowResult(result);
    }

    public string Ping()
    {
        return "Pong";
    }
}