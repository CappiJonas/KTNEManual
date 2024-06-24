using KTNEManual.Domain.ButtonModules;

namespace KTNEManual.Service.ButtonModuleServices.Interfaces
{
    public interface IHoldButtonService
    {
        string ReleasePressingButton(ButtonModule buttonModule, string bandColor);
    }
}
