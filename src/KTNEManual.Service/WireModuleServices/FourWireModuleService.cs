using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.WireModuleServices
{
    public class FourWireModuleService : IWireModuleService
    {
        public string CutWire(WireModule wireModule, int lastSerialDigit = 0)
        {
            if (wireModule.ColorList.Contains(Color.Red))
            {
                int countRedWire = wireModule.ColorList.Select(color => color == Color.Red).Count();

                if (countRedWire > 1 && lastSerialDigit % 2 == 1) 
                {
                    int position = wireModule.ColorList.LastIndexOf(Color.Red) + 1;
                    return string.Format(Message.WireModuleMessages.CutCustomWire, position);
                }
            }

            if (wireModule.ColorList.Last() == Color.Yellow 
                || wireModule.ColorList.Where(color => color == Color.Blue).Count() == 1)
                return Message.WireModuleMessages.CutFirstWire;

            if (wireModule.ColorList.Where(color => color == Color.Yellow).Count() > 1)
                return Message.WireModuleMessages.CutLastWire;

            return Message.WireModuleMessages.CutSecondWire;
        }
    }
}
