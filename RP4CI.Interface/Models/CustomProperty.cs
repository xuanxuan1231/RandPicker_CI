using CommunityToolkit.Mvvm.ComponentModel;

namespace RP4CI.Interface.Models;

public partial class CustomProperty : ObservableRecipient
{
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private string _value = string.Empty;
}