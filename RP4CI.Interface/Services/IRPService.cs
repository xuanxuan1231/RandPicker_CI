using dotnetCampus.Ipc.CompilerServices.Attributes;
using RP4CI.Interface.Models;

namespace RP4CI.Interface.Services;

[IpcPublic]
public interface IRPService
{
    void Notify(NotifyResult result);
    string PingService();
}