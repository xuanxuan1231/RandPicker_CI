using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Controls;
using ClassIsland.Core.Extensions.Registry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandPicker_CI.Services.NotificationProviders;

namespace RandPicker_CI;

[PluginEntrance]
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        AppBase.Current.AppStarted += async (_, _) =>
            await CommonTaskDialogs.ShowDialog("Hello world!", "Hello from RandPicker_CI!");
        services.AddNotificationProvider<RPNotificationProvider>();
    }
}