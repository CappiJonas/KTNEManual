using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.Service.Strategies.WireModuleStrategies.Interfaces;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.Strategies.WireModuleStrategies
{
    public class FourWireModuleStrategy : BaseStrategy, IWireModuleStrategy
    {
        private readonly IWireModuleService _service;
        private const int _countWire = 4;

        public FourWireModuleStrategy()
        {
            _service = new FourWireModuleService();
        }

        public string CreateWireModuleToCutWire()
        {
            var wireModule = ReturnWireModule(_countWire);
            int lastSerialDigit = ReturnLastDigitSerial();

            return _service.CutWire(wireModule!, lastSerialDigit);
        }
    }
}
