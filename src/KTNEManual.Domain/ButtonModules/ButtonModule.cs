using KTNEManual.Domain._Base;
using KTNEManual.Domain._Util;
using System.ComponentModel.DataAnnotations.Schema;

namespace KTNEManual.Domain.ButtonModules
{
    public class ButtonModule
    {
        private static Dictionary<string, Color> _bandColorMapping = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
        {
            { "branco", Color.White },
            { "azul", Color.Blue },
            { "amarelo", Color.Yellow }
        };

        private Dictionary<string, Color> _buttonColorMapping = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
        {
            { "vermelho", Color.Red }
        };

        private static List<string> _textList = new List<string>()
        {
            "Abortar",
            "Detonar",
            "Segure"
        };

        public Color ButtonColor { get; }
        public string ButtonText { get; }
        public Color BandColor { get; private set; }

        public ButtonModule(string color, string buttonText)
        {
            _buttonColorMapping.AddRange(_bandColorMapping);

            if (!_buttonColorMapping.TryGetValue(color, out Color buttonColor))
                throw new Exception(Message.ButtonModuleMessages.InvalidButtonColor);

            if (!_textList.Contains(buttonText))
                throw new Exception(Message.ButtonModuleMessages.InvalidButtonText);

            ButtonColor = buttonColor;
            ButtonText = buttonText;
        }

        public void SetBandColor(string bandColor)
        {
            if (_bandColorMapping.TryGetValue(bandColor, out Color color))
                BandColor = color;
            else
                BandColor = Color.Default;
        }
    }
}
