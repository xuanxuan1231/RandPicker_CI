using ClassIsland.Core;
using ClassIsland.Core.Abstractions;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Controls;
using ClassIsland.Core.Extensions.Registry;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RandPicker_CI.Services;
using RandPicker_CI.Services.NotificationProviders;

namespace RandPicker_CI;

[PluginEntrance]
public class Plugin : PluginBase
{
    public override void Initialize(HostBuilderContext context, IServiceCollection services)
    {
        // 注册通知提供者
        services.AddNotificationProvider<RPNotificationProvider>();
        
        // 注册并启动 IPC 服务
        services.AddHostedService<IpcService>();
    }
}
