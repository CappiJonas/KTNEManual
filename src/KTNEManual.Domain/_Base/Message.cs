namespace KTNEManual.Domain._Base
{
    public static class Message
    {
        public static class MainProgram
        {
            public static string PressButtonToContinue = "Aperte um botão para continuar...";
        }

        public static class WireModuleMessages
        {
            public static string InvalidWireCount = "Não há como criar um modulo de fios com menos de 3 fios nem com mais de 6 fios.";
            public static string InvalidWireColor = "Cor de fio informada inválida.";
            public static string CutSecondWire = "Corte o segundo fio.";
            public static string CutLastWire = "Corte o último fio.";
            public static string CutCustomWire = "Corte o {0}º fio.";
            public static string CutFirstWire = "Corte o primeiro fio.";
            public static string CutFourthWire = "Corte o quarto fio.";
            public static string CutThirdWire = "Corte o terceiro fio.";
            public static string InvalidAnswer = "Resposta inválida para quantidade de fios.";
        }

        public static class ButtonModuleMessages
        {
            public static string InvalidButtonColor = "Cor de botão inválida.";
            public static string InvalidButtonText = "Texto do botão inválido.";
            public static string InvalidNumberOfBatteries = "Número de passado de baterias inválido. Informe um número válido.";
            public static string ReleaseWhenTimeIsFourAnyPosition = "Solte o botão quando o marcador de tempo estiver no 4 em qualquer posição.";
            public static string ReleaseWhenTimeIsOneAnyPosition = "Solte o botão quando o marcador de tempo estiver no 1 em qualquer posição.";
            public static string ReleaseWhenTimeIsFiveAnyPosition = "Solte o botão quando o marcador de tempo estiver no 5 em qualquer posição.";
            public static string PressAndReleaseButton = "Aperte o botão e solte imediatamente.";
            public static string PressAndHoldButton = "Aperte e segure o botão.";
        }
    }
}
