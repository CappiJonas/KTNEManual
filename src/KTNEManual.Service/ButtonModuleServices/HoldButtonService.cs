using KTNEManual.Domain._Base;
using KTNEManual.Domain.ButtonModules;
using KTNEManual.Service.ButtonModuleServices.Interfaces;

namespace KTNEManual.Service.ButtonModuleServices
{
    public class HoldButtonService : IHoldButtonService
    {
        public string ReleasePressingButton(ButtonModule buttonModule, string bandColor)
        {
            buttonModule.SetBandColor(bandColor);

            if (buttonModule.BandColor == Color.Blue)
                return Message.ButtonModuleMessages.ReleaseWhenTimeIsFourAnyPosition;
            
            if (buttonModule.BandColor == Color.Yellow)
                return Message.ButtonModuleMessages.ReleaseWhenTimeIsFiveAnyPosition;

            return Message.ButtonModuleMessages.ReleaseWhenTimeIsOneAnyPosition;
        }
    }
}
