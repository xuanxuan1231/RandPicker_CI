using System.Text.Json.Serialization;

namespace RandPicker_CI.Models;

public class NotificationData
{
    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;
}
