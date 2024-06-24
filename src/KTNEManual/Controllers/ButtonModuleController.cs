using KTNEManual.Domain._Base;
using KTNEManual.Domain.ButtonModules;
using KTNEManual.Service.ButtonModuleServices;
using KTNEManual.Service.ButtonModuleServices.Interfaces;

namespace KTNEManual.Controllers
{
    public class ButtonModuleController
    {
        private readonly IPressButtonService _pressButtonService;
        private readonly IHoldButtonService _holdButtonService;
        private bool _process;

        public ButtonModuleController()
        {
            _pressButtonService = new PressButtonService();
            _holdButtonService = new HoldButtonService();
            _process = true;
        }

        public void PressButton()
        {
            ButtonModule? buttonModule = null;
            int numberOfBatteries = 0;
            string answer = string.Empty;

            while (_process)
            {
                Console.WriteLine("Qual a cor do botão?");
                string buttonColor = Console.ReadLine()!.ToLower();

                Console.WriteLine("Qual é o texto do botão?");
                string buttonText = Console.ReadLine()!;

                try
                {
                    buttonModule = new ButtonModule(buttonColor, buttonText);
                    _process = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Message.MainProgram.PressButtonToContinue);
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            _process = true;

            while(_process)
            {
                Console.WriteLine("Quantas pilhas há na bomba?");
                answer = Console.ReadLine()!;

                if (!int.TryParse(answer, out numberOfBatteries))
                {
                    Console.WriteLine(Message.ButtonModuleMessages.InvalidNumberOfBatteries);
                    continue;
                }

                _process = false;
            }

            Console.WriteLine("Há um indicador aceso escrito CAR? (S - Sim/N - Não)");
            answer = Console.ReadLine()!.ToUpper();
            bool isIndicatorOnCAR = answer == "S";

            Console.WriteLine("Há um indicador aceso escrito FRK? (S - Sim/N - Não)");
            answer = Console.ReadLine()!.ToUpper();
            bool isIndicatorOnFRK = answer == "S";

            var result = _pressButtonService.ShouldPressAndRelease(buttonModule!, numberOfBatteries, isIndicatorOnCAR, isIndicatorOnFRK);

            if (result)
                Console.WriteLine(Message.ButtonModuleMessages.PressAndReleaseButton);
            else
            {
                Console.WriteLine(Message.ButtonModuleMessages.PressAndHoldButton);
                Console.WriteLine("Qual a cor da faixa?");
                string bandColor = Console.ReadLine()!.ToLower();
                Console.WriteLine(_holdButtonService.ReleasePressingButton(buttonModule!, bandColor));
            }
        }
    }
}
