using KTNEManual.Controllers;
using KTNEManual.Domain._Base;

Console.WriteLine("Olá, seja bem-vindo ao Sistema do Manual do 'Keep Talking and Nobody Explodes'!!!");
Console.WriteLine(Message.MainProgram.PressButtonToContinue);
Console.ReadKey();
Console.Clear();

bool proceed = true;

while (proceed)
{
    Console.WriteLine("Escolha um dos módulos através de seu número correspondente");
    Console.WriteLine("1 - A Respeito dos Fios");
    Console.WriteLine("2 - A Respeito do Botão");
    Console.Write("Resposta: ");
    string answer = Console.ReadLine()!;

    if (!int.TryParse(answer, out int chosenModule))
    {
        Console.WriteLine("Resposta inválida para escolha de módulo.");
        Console.WriteLine(Message.MainProgram.PressButtonToContinue);
        Console.ReadKey();
        Console.Clear();
        continue;
    }

    Console.Clear();

    switch (chosenModule)
    {
        case 1:
            var wireModuleController = new WireModuleController();
            wireModuleController.SetWireModule();
            break;
        case 2:
            var buttonModuleController = new ButtonModuleController();
            buttonModuleController.PressButton();
            break;
        default:
            Console.WriteLine("Opção escolhida inválida. Aperte um botão para escolher novamente...");
            Console.ReadKey();
            Console.Clear();
            continue;
    }

    Console.WriteLine(Message.MainProgram.PressButtonToContinue);
    Console.ReadKey();

    Console.Clear();

    Console.WriteLine("Gostaria de continuar? (S - Sim/N - Não)");
    answer = Console.ReadLine()!.ToUpper();

    if (answer == "N")
        proceed = false;

    Console.Clear();
}

Console.WriteLine("Obrigado por utilizar esse sistema!!!");
Console.WriteLine("Volte sempre!!!");