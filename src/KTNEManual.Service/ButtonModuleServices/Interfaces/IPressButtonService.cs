using KTNEManual.Domain.ButtonModules;

namespace KTNEManual.Service.ButtonModuleServices.Interfaces
{
    public interface IPressButtonService
    {
        bool ShouldPressAndRelease(ButtonModule buttonModule, int numberOfBatteries, bool isIndicatorOnCAR, bool isIndicatorOnFRK);
    }
}
