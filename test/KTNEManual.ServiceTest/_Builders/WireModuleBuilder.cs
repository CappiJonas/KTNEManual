using KTNEManual.Domain.WireModules;

namespace KTNEManual.ServiceTest._Builders
{
    public class WireModuleBuilder
    {
        private List<string> _colorList = new List<string>()
        {
            "branco",
            "amarelo",
            "preto"
        };

        public static WireModuleBuilder New()
        {
            return new WireModuleBuilder();
        }

        public WireModuleBuilder WithColors(string colors)
        {
            _colorList = colors.Split(',').ToList();
            return this;
        }

        public WireModule Build()
        {
            var wireModule = new WireModule(_colorList);
            return wireModule;
        }
    }
}
