using KTNEManual.Service.Strategies.WireModuleStrategies.Interfaces;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.Strategies.WireModuleStrategies
{
    public class SixWireModuleStrategy : BaseStrategy, IWireModuleStrategy
    {
        private readonly IWireModuleService _service;
        private const int _countWire = 6;

        public SixWireModuleStrategy()
        {
            _service = new SixWireModuleService();
        }

        public string CreateWireModuleToCutWire()
        {
            var wireModule = ReturnWireModule(_countWire);
            int lastSerialDigit = ReturnLastDigitSerial();

            return _service.CutWire(wireModule!, lastSerialDigit);
        }
    }
}
