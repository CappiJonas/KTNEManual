using KTNEManual.Domain.WireModules;

namespace KTNEManual.Service.WireModuleServices.Interfaces
{
    public interface IWireModuleService
    {
        string CutWire(WireModule wireModule, int lastSerialDigit = 0);
    }
}
