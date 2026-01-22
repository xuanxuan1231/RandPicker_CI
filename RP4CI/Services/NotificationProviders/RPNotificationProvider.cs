
using ClassIsland.Core.Abstractions.Services.NotificationProviders;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Models.Notification;
using RP4CI.Shared.Models;

namespace RP4CI.Services.NotificationProviders;

[NotificationProviderInfo("63B97A6F-BA5C-0C84-C3AD-EE53A9069895", "RandPicker", "PackIconKind.Airplane", "RandPicker 抽选结果的提醒。")]
[NotificationChannelInfo("3C4518B7-D15D-1F9B-4474-1ED02BE2F229", "选人通知", "", "RandPicker 选人结果的提醒。")]
[NotificationChannelInfo("12047D56-FAC7-1830-A535-903F693E0D98", "选组通知", "", "RandPicker 选组结果的提醒。")]
public class RPNotificationProvider : NotificationProviderBase
{
    private NotificationRequest? _request = null;
    public void ShowResult(NotifyResult result)
    {
        if (_request != null)
        {
            return;
            // 以后再写吧（
        }
        _request = new NotificationRequest();
        _request.ChannelId = result.PickType == PickType.Person ? new Guid("3C4518B7-D15D-1F9B-4474-1ED02BE2F229") : new Guid("12047D56-FAC7-1830-A535-903F693E0D98");
        _request.MaskContent = NotificationContent.CreateTwoIconsMask(result.Title, factory: x =>
        {
            x.Duration = TimeSpan.FromSeconds(result.TitleDuration);
        });
        if (result.OverlayType == OverlayType.Rolling)
        {
            _request.OverlayContent = NotificationContent.CreateRollingTextContent(result.Overlay, factory: x =>
            {
                x.Duration = TimeSpan.FromSeconds(result.OverlayDuration);
            });
        }
        else
        {
            _request.OverlayContent = NotificationContent.CreateSimpleTextContent(result.Overlay, factory: x =>
            {
                x.Duration = TimeSpan.FromSeconds(result.OverlayDuration);
            });
        }
        ShowNotification(_request);

    }
}