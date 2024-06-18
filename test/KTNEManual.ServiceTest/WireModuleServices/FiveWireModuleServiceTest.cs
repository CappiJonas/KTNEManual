using KTNEManual.Domain._Base;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.ServiceTest._Builders;

namespace KTNEManual.ServiceTest.WireModuleServices
{
    public class FiveWireModuleServiceTest
    {
        private readonly FiveWireModuleService _service;

        public FiveWireModuleServiceTest()
        {
            _service = new FiveWireModuleService();
        }

        [Fact]
        public void ShouldCutFirstWireIfLastWireIsBlackAndLastSerialDigitIsOdd()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("branco,azul,vermelho,amarelo,preto").Build();
            var lastSerialOddDigit = 1;

            //Act
            var message = _service.CutWire(wireModule, lastSerialOddDigit);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutFourthWire, message);
        }

        [Theory]
        [InlineData("branco,azul,vermelho,amarelo,amarelo")]
        [InlineData("amarelo,azul,vermelho,amarelo,amarelo")]
        [InlineData("amarelo,amarelo,vermelho,amarelo,amarelo")]
        public void ShouldCutFirstWireIfHaveOnlyOneRedWireAndMoreThanOneYellowWire(string colors)
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors(colors).Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutFirstWire, message);
        }

        [Fact]
        public void ShouldCutSecondWireIfDoesntHaveBlackWire()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("branco,azul,vermelho,amarelo,vermelho").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutSecondWire, message);
        }

        [Fact]
        public void ShouldCutFirstWireIfDoesntHaveTheOthersConditions()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("branco,azul,preto,amarelo,vermelho").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutFirstWire, message);
        }
    }
}
