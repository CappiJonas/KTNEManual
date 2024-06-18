using KTNEManual.Domain._Base;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.ServiceTest._Builders;

namespace KTNEManual.ServiceTest.WireModuleServices
{
    public class SixWireModuleServiceTest
    {
        private readonly SixWireModuleService _service;

        public SixWireModuleServiceTest()
        {
            _service = new SixWireModuleService();
        }

        [Fact]
        public void ShouldCutThirdWireIfDoesntHaveYellowWireAndLastSerialDigitIsOdd()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("branco,preto,azul,vermelho,preto,branco").Build();
            var lastSerialOddDigit = 1;

            //Act
            var message = _service.CutWire(wireModule, lastSerialOddDigit);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutThirdWire, message);
        }

        [Theory]
        [InlineData("amarelo,branco,branco,vermelho,preto,azul")]
        [InlineData("amarelo,branco,branco,branco,preto,azul")]
        [InlineData("amarelo,branco,branco,branco,branco,azul")]
        [InlineData("amarelo,branco,branco,branco,branco,branco")]
        public void ShouldCutFourthWireIfHaveOnlyOneYellowWireAndMoreThanOneWhiteWire(string colors)
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors(colors).Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutFourthWire, message);
        }

        [Fact]
        public void ShouldCutLastWireIfDoesntHaveRedWire()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("amarelo,amarelo,branco,preto,preto,azul").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutLastWire, message);
        }

        [Fact]
        public void ShouldCutFourthWireIfDoesntHaveTheOthersConditions()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("amarelo,vermelho,branco,azul,preto,azul").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutFourthWire, message);
        }
    }
}
