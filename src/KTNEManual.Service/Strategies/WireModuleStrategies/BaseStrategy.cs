using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTNEManual.Service.Strategies.WireModuleStrategies
{
    public class BaseStrategy
    {
        private static bool _process;

        protected static WireModule? ReturnWireModule(int countWire)
        {
            _process = true;
            WireModule? wireModule = null;

            while (_process)
            {
                List<string> colorList = new List<string>();

                for (int i = 1; i <= countWire; i++)
                {
                    Console.WriteLine($"Qual a cor do {i}º fio?");
                    string color = Console.ReadLine()!.ToLower();
                    colorList.Add(color);
                }

                try
                {
                    wireModule = new WireModule(colorList);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(Message.MainProgram.PressButtonToContinue);
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }

                _process = false;
            }

            return wireModule;
        }

        protected static int ReturnLastDigitSerial()
        {
            int lastSerialDigit = 0;
            _process = true;

            while (_process)
            {
                Console.WriteLine("Qual o número do último dígito do serial?");
                string answer = Console.ReadLine()!;

                if (!int.TryParse(answer, out lastSerialDigit))
                {
                    Console.WriteLine("O número passado na última resposta é inválido.");
                    Console.WriteLine(Message.MainProgram.PressButtonToContinue);
                    Console.ReadKey();
                    continue;
                }

                _process = false;
            }

            return lastSerialDigit;
        }
    }
}
