using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.Service.Strategies.WireModuleStrategies.Interfaces;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.Strategies.WireModuleStrategies
{
    public class ThreeWireModuleStrategy : BaseStrategy, IWireModuleStrategy
    {
        private readonly IWireModuleService _service;
        private const int _countWire = 3;

        public ThreeWireModuleStrategy()
        {
            _service = new ThreeWireModuleService();
        }

        public string CreateWireModuleToCutWire()
        {
            var wireModule = ReturnWireModule(_countWire);

            return _service.CutWire(wireModule!);
        }
    }
}
