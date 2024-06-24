using KTNEManual.Domain._Base;
using KTNEManual.Domain.ButtonModules;
using KTNEManual.Service.ButtonModuleServices.Interfaces;

namespace KTNEManual.Service.ButtonModuleServices
{
    public class PressButtonService : IPressButtonService
    {
        public bool ShouldPressAndRelease(ButtonModule buttonModule, int numberOfBatteries, bool isIndicatorOnCAR, bool isIndicatorOnFRK)
        {
            bool shouldPressAndRelease = true;

            if (buttonModule.ButtonColor == Color.Blue && buttonModule.ButtonText == "Abortar")
                return !shouldPressAndRelease;

            if (buttonModule.ButtonText == "Detonar" && numberOfBatteries > 1)
                return shouldPressAndRelease;

            if (buttonModule.ButtonColor == Color.White && isIndicatorOnCAR)
                return !shouldPressAndRelease;

            if (numberOfBatteries > 2 && isIndicatorOnFRK)
                return shouldPressAndRelease;

            if (buttonModule.ButtonColor == Color.Yellow)
                return !shouldPressAndRelease;

            if (buttonModule.ButtonColor == Color.Red && buttonModule.ButtonText == "Segure")
                return shouldPressAndRelease;

            return !shouldPressAndRelease;
        }
    }
}
