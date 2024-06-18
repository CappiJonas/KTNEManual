using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.WireModuleServices
{
    public class FiveWireModuleService : IWireModuleService
    {
        public string CutWire(WireModule wireModule, int lastSerialDigit = 0)
        {
            if (wireModule.ColorList.Last() == Color.Black && lastSerialDigit % 2 == 1)
                return Message.WireModuleMessages.CutFourthWire;

            if (wireModule.ColorList.Where(color => color == Color.Red).Count() == 1
                && wireModule.ColorList.Where(color => color == Color.Yellow).Count() > 1)
                return Message.WireModuleMessages.CutFirstWire;

            if (!wireModule.ColorList.Contains(Color.Black))
                return Message.WireModuleMessages.CutSecondWire;

            return Message.WireModuleMessages.CutFirstWire;
        }
    }
}
