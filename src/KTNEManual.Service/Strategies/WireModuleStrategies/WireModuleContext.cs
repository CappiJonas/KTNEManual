using KTNEManual.Domain._Base;
using KTNEManual.Service.Strategies.WireModuleStrategies.Interfaces;

namespace KTNEManual.Service.Strategies.WireModuleStrategies
{
    public class WireModuleContext
    {
        private IWireModuleStrategy? _strategy;

        public void ShowWhatWireToCut()
        {
            bool process = true;

            while (process)
            {
                Console.WriteLine("Quantos fios há no módulo?");
                string answer = Console.ReadLine()!;

                if (!int.TryParse(answer, out int countWire))
                {
                    Console.WriteLine(Message.WireModuleMessages.InvalidAnswer);
                    Console.WriteLine(Message.MainProgram.PressButtonToContinue);
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                switch (countWire)
                {
                    case 3:
                        _strategy = new ThreeWireModuleStrategy();
                        break;
                    case 4:
                        _strategy = new FourWireModuleStrategy();
                        break;
                    case 5:
                        _strategy = new FiveWireModuleStrategy();
                        break;
                    case 6:
                        _strategy = new SixWireModuleStrategy();
                        break;
                    default:
                        Console.WriteLine(Message.WireModuleMessages.InvalidWireCount);
                        Console.WriteLine(Message.MainProgram.PressButtonToContinue);
                        Console.ReadKey();
                        Console.Clear();
                        continue;

                }

                Console.Clear();

                Console.WriteLine(_strategy.CreateWireModuleToCutWire());

                process = false;
            }
        }
    }
}
