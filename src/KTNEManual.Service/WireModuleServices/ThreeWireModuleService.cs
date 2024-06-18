using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.Service.WireModuleServices.Interfaces;

namespace KTNEManual.Service.WireModuleServices
{
    public class ThreeWireModuleService : IWireModuleService
    {
        public string CutWire(WireModule wireModule, int lastSerialDigit = 0)
        {
            if (!wireModule.ColorList.Contains(Color.Red))
                return Message.WireModuleMessages.CutSecondWire;

            if (wireModule.ColorList.Contains(Color.Blue))
            {
                int countBlueWire = wireModule.ColorList.Where(color => color == Color.Blue).Count();

                if (countBlueWire > 1)
                {
                    int position = wireModule.ColorList.LastIndexOf(Color.Blue) + 1;
                    return string.Format(Message.WireModuleMessages.CutCustomWire, position);
                }
            }

            return Message.WireModuleMessages.CutLastWire;
        }
    }
}
