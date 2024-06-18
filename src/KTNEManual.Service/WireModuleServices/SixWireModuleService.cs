using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.WireModuleServices
{
    public class SixWireModuleService : IWireModuleService
    {
        public string CutWire(WireModule wireModule, int lastSerialDigit = 0)
        {
            if (!wireModule.ColorList.Contains(Color.Yellow) && lastSerialDigit % 2 == 1)
                return Message.WireModuleMessages.CutThirdWire;

            if (wireModule.ColorList.Where(color => color == Color.Yellow).Count() == 1
                && wireModule.ColorList.Where(color => color == Color.White).Count() > 1)
                return Message.WireModuleMessages.CutFourthWire;

            if (!wireModule.ColorList.Contains(Color.Red))
                return Message.WireModuleMessages.CutLastWire;

            return Message.WireModuleMessages.CutFourthWire;
        }
    }
}
