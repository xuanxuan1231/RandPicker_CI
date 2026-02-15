using CommunityToolkit.Mvvm.ComponentModel;

namespace RP4CI.Interface.Models;

public partial class PickGroup : ObservableRecipient
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private List<PickStudent>? _studentList;
    [ObservableProperty] private int _weight = 1;
    [ObservableProperty] private bool _active = true;
}