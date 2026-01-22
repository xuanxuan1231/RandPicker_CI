
using ClassIsland.Core.Abstractions.Services;
using ClassIsland.Core.Abstractions.Services.NotificationProviders;
using ClassIsland.Core.Attributes;
using ClassIsland.Core.Models.Notification;
using ClassIsland.Core.Models.Notification.Templates;

namespace RandPicker_CI.Services.NotificationProviders;

[NotificationProviderInfo("63B97A6F-BA5C-0C84-C3AD-EE53A9069895", "RandPicker", "PackIconKind.Airplane", "RandPicker 抽选结果的提醒。")]

public class RPNotificationProvider : NotificationProviderBase
{
    public ILessonsService LessonsService { get; }

    public RPNotificationProvider(ILessonsService lessonsService)
    {
        LessonsService = lessonsService;  // 将课程服务实例保存到属性中备用
        LessonsService.OnBreakingTime += LessonsServiceOnOnBreakingTime;  // 注册下课事件
    }

    private void LessonsServiceOnOnBreakingTime(object? sender, EventArgs e)
    {
        ShowNotification(new NotificationRequest()
        {
            MaskContent = NotificationContent.CreateTwoIconsMask("Hello world!", factory: content =>
            {
                content.Duration = TimeSpan.FromSeconds(2); // 设置通知显示时间为2秒
            })
        });
    }
}