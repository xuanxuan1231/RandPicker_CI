using CommunityToolkit.Mvvm.ComponentModel;

namespace RP4CI.Shared.Models;

public enum OverlayType { Simple, Rolling }
public enum PickType { Person, Group, Test }

public partial class NotifyResult : ObservableObject
{
    [ObservableProperty] private string _title = string.Empty;
    [ObservableProperty] private string _overlay = string.Empty;
    [ObservableProperty] private int _titleDuration;
    [ObservableProperty] private int _overlayDuration;
    [ObservableProperty] private OverlayType _overlayType = OverlayType.Simple;
    [ObservableProperty] private PickType _pickType = PickType.Person;
}