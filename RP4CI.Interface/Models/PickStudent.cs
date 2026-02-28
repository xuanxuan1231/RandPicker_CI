using CommunityToolkit.Mvvm.ComponentModel;

namespace RP4CI.Interface.Models;

public partial class PickStudent : ObservableRecipient
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private List<CustomProperty>? _customProperties;
    [ObservableProperty] private double _weight = 1.0;
    [ObservableProperty] private bool _active = true;
}