using ExpectedObjects;
using KTNEManual.Domain._Base;
using KTNEManual.Domain.WireModules;
using KTNEManual.DomainTest._Util;

namespace KTNEManual.DomainTest.WireModules
{
    public class WireModuleTest
    {
        private List<string>? _colorList;

        [Fact]
        public void ShouldCreateWireModule()
        {
            //Arrange
            _colorList = new List<string>()
            {
                "branco",
                "vermelho",
                "azul",
                "amarelo",
                "preto"
            };
            var wireModuleExpected = new
            {
                ColorList = new List<Color>()
                {
                    Color.White,
                    Color.Red,
                    Color.Blue,
                    Color.Yellow, 
                    Color.Black
                }
            };

            //Act
            var wireModule = new WireModule(_colorList);

            //Assert
            wireModuleExpected.ToExpectedObject().ShouldMatch(wireModule);
        }

        [Theory]
        [InlineData("branco,azul")]
        [InlineData("branco,vermelho,azul,preto,amarelo,branco,preto")]
        public void ShouldNotCreateWireModuleWithInvalidWiresCount(string colors)
        {
            //Arrange
            _colorList = colors.Split(',').ToList();

            //Act
            //Assert
            Assert.Throws<Exception>(() => new WireModule(_colorList))
                .WithMessage(Message.WireModuleMessages.InvalidWireCount);
        }

        [Fact]
        public void ShouldNotCreateWireModuleWithInvalidWireColor()
        {
            //Arrange
            _colorList = new List<string>()
            {
                "branco",
                "azul",
                "rosa"
            };

            //Act
            //Assert
            Assert.Throws<Exception>(() => new WireModule(_colorList))
                .WithMessage(Message.WireModuleMessages.InvalidWireColor);
        }
    }
}
