using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Extensions.Registry;
using ClassIsland.Shared;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RP4CI.Services;
using RP4CI.Services.NotificationProviders;

namespace RP4CI;

[PluginEntrance]
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        services.AddNotificationProvider<RPNotificationProvider>();
        services.AddSingleton<RPService>();
        
        AppBase.Current.AppStarted += (sender, args) =>
        {
            IAppHost.GetService<RPService>();
        };
    }
}