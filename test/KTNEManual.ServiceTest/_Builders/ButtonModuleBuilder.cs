using KTNEManual.Domain.ButtonModules;

namespace KTNEManual.ServiceTest._Builders
{
    public class ButtonModuleBuilder
    {
        private string _buttonColor = "vermelho";
        private string _buttonText = "Detonar";

        public static ButtonModuleBuilder New()
        {
            return new ButtonModuleBuilder();
        }

        public ButtonModuleBuilder WithButtonColor(string buttonColor)
        {
            _buttonColor = buttonColor;
            return this;
        }

        public ButtonModuleBuilder WithButtonText(string buttonText)
        {
            _buttonText = buttonText;
            return this;
        }

        public ButtonModule Build()
        {
            var buttonModule = new ButtonModule(_buttonColor, _buttonText);
            return buttonModule;
        }
    }
}
