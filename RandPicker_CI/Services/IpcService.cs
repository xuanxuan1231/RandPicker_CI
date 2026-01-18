using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RandPicker_CI.Models;

namespace RandPicker_CI.Services;

public class IpcService : BackgroundService
{
    private readonly ILogger<IpcService> _logger;
    private readonly RPNotificationProvider _notificationProvider;
    private const int Port = 58210;

    public IpcService(ILogger<IpcService> logger, RPNotificationProvider notificationProvider)
    {
        _logger = logger;
        _notificationProvider = notificationProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var listener = new TcpListener(IPAddress.Loopback, Port);
        try
        {
            listener.Start();
            _logger.LogInformation("RandPicker_CI IPC 服务已启动，监听端口 {Port}", Port);

            while (!stoppingToken.IsCancellationRequested)
            {
                using var client = await listener.AcceptTcpClientAsync(stoppingToken);
                _logger.LogInformation("收到来自 RandPicker 的连接");
                
                using var stream = client.GetStream();
                var buffer = new byte[1024];
                var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length, stoppingToken);
                
                if (bytesRead > 0)
                {
                    var json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var data = JsonSerializer.Deserialize<NotificationData>(json);
                    
                    if (data != null)
                    {
                        _logger.LogInformation("收到通知请求: {Title} - {Message}", data.Title, data.Message);
                        _notificationProvider.ShowRpNotification(data.Title, data.Message);
                    }
                }
            }
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            _logger.LogError(ex, "IPC 服务运行出错");
        }
        finally
        {
            listener.Stop();
        }
    }
}
