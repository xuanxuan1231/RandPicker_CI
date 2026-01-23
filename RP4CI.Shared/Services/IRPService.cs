using dotnetCampus.Ipc.CompilerServices.Attributes;
using RP4CI.Shared.Models;

namespace RP4CI.Shared.Services;

[IpcPublic]
public interface IRPService
{
    void Notify(NotifyResult result);
    string PingService();
}