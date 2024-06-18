using KTNEManual.Domain._Base;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.ServiceTest._Builders;

namespace KTNEManual.ServiceTest.WireModuleServices
{
    public class FourWireModuleServiceTest
    {
        private readonly FourWireModuleService _service;

        public FourWireModuleServiceTest()
        {
            _service = new FourWireModuleService();
        }

        [Theory]
        [InlineData("vermelho,vermelho,branco,branco", 3, 2)]
        [InlineData("vermelho,vermelho,vermelho,branco", 3, 3)]
        [InlineData("vermelho,vermelho,branco,vermelho", 3, 4)]
        public void ShouldCutLastRedWireIfHaveMoreThanOneRedWireAndLastSerialDigitIsOdd(string colors, int lastSerialDigit, int position)
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors(colors).Build();

            //Act
            var message = _service.CutWire(wireModule, lastSerialDigit);

            //Arrange
            Assert.Equal(string.Format(Message.WireModuleMessages.CutCustomWire, position), message);
        }

        [Fact]
        public void ShouldCutFirstWireIfHaveLastYellowWireAndNoneRedWires()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("branco,branco,preto,amarelo").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Arrange
            Assert.Equal(Message.WireModuleMessages.CutFirstWire, message);
        }

        [Theory]
        [InlineData("azul,branco,preto,branco")]
        [InlineData("branco,azul,preto,branco")]
        [InlineData("branco,preto,azul,branco")]
        [InlineData("branco,branco,preto,azul")]
        public void ShouldCutFirstWireIfHaveOnlyOneBlueWire(string colors)
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors(colors).Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Arrange
            Assert.Equal(Message.WireModuleMessages.CutFirstWire, message);
        }

        [Theory]
        [InlineData("amarelo,vermelho,amarelo,preto")]
        [InlineData("amarelo,amarelo,amarelo,preto")]
        public void ShouldCutLastWireIfHaveMoreThanOneYellowWire(string colors)
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors(colors).Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Arrange
            Assert.Equal(Message.WireModuleMessages.CutLastWire, message);
        }

        [Fact]
        public void ShouldCutSecondWireIfDoesntHaveTheOthersConditions()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("branco,branco,branco,branco").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Arrange
            Assert.Equal(Message.WireModuleMessages.CutSecondWire, message);
        }
    }
}
