using ExpectedObjects;
using KTNEManual.Domain._Base;
using KTNEManual.Domain.ButtonModules;
using KTNEManual.DomainTest._Util;

namespace KTNEManual.DomainTest.ButtonModules
{
    public class ButtonModuleTest
    {
        private readonly string _validButtonColor;
        private readonly string _validButtonText;

        public ButtonModuleTest()
        {
            _validButtonColor = "vermelho";
            _validButtonText = "Detonar";
        }

        [Fact]
        public void ShouldCreateButtonModule()
        {
            //Arrange
            var buttonModuleExpected = new
            {
                ButtonColor = Color.Red,
                ButtonText = _validButtonText
            };

            //Act
            var buttonModule = new ButtonModule(_validButtonColor, buttonModuleExpected.ButtonText);

            //Assert
            buttonModuleExpected.ToExpectedObject().ShouldMatch(buttonModule);
        }

        [Fact]
        public void ShouldNotCreateButtonModuleWithInvalidButtonColor()
        {
            //Arrange
            string invalidButtonColor = "preto";

            //Act
            //Assert
            Assert.Throws<Exception>(() => new ButtonModule(invalidButtonColor, _validButtonText))
                .WithMessage(Message.ButtonModuleMessages.InvalidButtonColor);
        }

        [Fact]
        public void ShouldNotCreateButtonModuleWithInvalidButtonText()
        {
            //Arrange
            string invalidButtonText = "Teste";

            //Act
            //Assert
            Assert.Throws<Exception>(() => new ButtonModule("vermelho", invalidButtonText))
                .WithMessage(Message.ButtonModuleMessages.InvalidButtonText);
        }

        [Theory]
        [InlineData("azul", Color.Blue)]
        [InlineData("branco", Color.White)]
        [InlineData("amarelo", Color.Yellow)]
        public void ShouldSetBandColor(string bandColor, Color bandColorExpected)
        {
            //Arrange
            var buttonModule = new ButtonModule(_validButtonColor, _validButtonText);

            //Act
            buttonModule.SetBandColor(bandColor);

            //Assert
            Assert.Equal(bandColorExpected, buttonModule.BandColor);
        }

        [Fact]
        public void ShouldSetDefaultBandColor()
        {
            //Arrange
            string bandColor = _validButtonColor;
            Color bandColorExpected = Color.Default;
            var buttonModule = new ButtonModule(_validButtonColor, _validButtonText);

            //Act
            buttonModule.SetBandColor(bandColor);

            //Assert
            Assert.Equal(bandColorExpected, buttonModule.BandColor);
        }
    }
}
