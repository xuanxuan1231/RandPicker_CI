using Avalonia.Threading;
using ClassIsland.Core.Abstractions.Services.NotificationProviders;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Models.Notification;
using RP4CI.Interface.Models;

namespace RP4CI.Services.NotificationProviders;

[NotificationProviderInfo("63B97A6F-BA5C-0C84-C3AD-EE53A9069895", "RandPicker", "PackIconKind.Airplane", "RandPicker 抽选结果的提醒。")]
[NotificationChannelInfo("3C4518B7-D15D-1F9B-4474-1ED02BE2F229", "选人通知", "", "RandPicker 选人结果的提醒。")]
[NotificationChannelInfo("12047D56-FAC7-1830-A535-903F693E0D98", "选组通知", "", "RandPicker 选组结果的提醒。")]
[NotificationChannelInfo("044C77DA-01C4-2027-6E66-C6CEF9E9E096", "测试通知", "", "RandPicker 测试通知。")]
public class RPNotificationProvider : NotificationProviderBase
{
    private NotificationRequest? _request = null;
    public void ShowResult(NotifyResult result)
    {
        // TODO)) 以后再写吧（
        /*if (_request != null)
        {
            return;
        }*/
        Dispatcher.UIThread.Invoke(() =>
        {
            _request = new NotificationRequest();

            _request.ChannelId = result.PickType switch
            {
                PickType.Test => new Guid("044C77DA-01C4-2027-6E66-C6CEF9E9E096"),
                PickType.Person => new Guid("3C4518B7-D15D-1F9B-4474-1ED02BE2F229"),
                _ => new Guid("12047D56-FAC7-1830-A535-903F693E0D98")
            };
            _request.MaskContent = NotificationContent.CreateTwoIconsMask(result.Title,
                factory: x =>
                {
                    x.Duration = TimeSpan.FromSeconds(result.TitleDuration == 0 ? 2 : result.TitleDuration);
                });
            if (result.OverlayType == OverlayType.Rolling)
            {
                _request.OverlayContent = NotificationContent.CreateRollingTextContent(result.Overlay,
                    factory: x =>
                    {
                        x.Duration = TimeSpan.FromSeconds(result.OverlayDuration == 0 ? 5 : result.OverlayDuration);
                    });
            }
            else
            {
                _request.OverlayContent = NotificationContent.CreateSimpleTextContent(result.Overlay,
                    factory: x =>
                    {
                        x.Duration = TimeSpan.FromSeconds(result.OverlayDuration == 0 ? 5 : result.OverlayDuration);
                    });
            }
            _request.CompletedToken.Register(() => _request = null);
            ShowNotification(_request);
        });
    }
}