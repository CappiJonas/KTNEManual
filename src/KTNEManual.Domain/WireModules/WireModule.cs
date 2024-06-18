using KTNEManual.Domain._Base;

namespace KTNEManual.Domain.WireModules
{
    public class WireModule
    {
        private Dictionary<string, Color> _colorMapping = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase)
        {
            { "branco", Color.White },
            { "vermelho", Color.Red },
            { "azul", Color.Blue },
            { "amarelo", Color.Yellow },
            { "preto", Color.Black }
        };

        public List<Color> ColorList { get; set; }

        public WireModule(List<string> colorList)
        {
            if (colorList.Count < 3 || colorList.Count > 6)
                throw new Exception(Message.WireModuleMessages.InvalidWireCount);

            if (!TryGetColors(colorList, out List<Color> colors))
                throw new Exception(Message.WireModuleMessages.InvalidWireColor);

            ColorList = colors;
        } 
        
        private bool TryGetColors(List<string> colorList, out List<Color> colors)
        {
            colors = new List<Color>();

            foreach (var color in colorList)
            {
                if (!_colorMapping.TryGetValue(color, out Color colorEnum))
                    return false;

                colors.Add(colorEnum);
            }

            return true;
        }
    }
}
