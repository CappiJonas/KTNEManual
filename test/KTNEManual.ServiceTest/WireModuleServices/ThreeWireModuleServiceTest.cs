using KTNEManual.Domain._Base;
using KTNEManual.Service.WireModuleServices;
using KTNEManual.ServiceTest._Builders;

namespace KTNEManual.ServiceTest.WireModuleServices
{
    public class ThreeWireModuleServiceTest
    {
        private readonly ThreeWireModuleService _service;

        public ThreeWireModuleServiceTest()
        {
            _service = new ThreeWireModuleService();
        }

        [Fact]
        public void ShouldCutSecondWireIfDoesntHaveRedWire()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutSecondWire, message);
        }

        [Fact]
        public void ShouldCutLastWireIfHaveRedWireAndLastWhiteWire()
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors("vermelho,preto,branco").Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(Message.WireModuleMessages.CutLastWire, message);
        }

        [Theory]
        [InlineData("azul,azul,vermelho", 2)]
        [InlineData("azul,vermelho,azul", 3)]
        public void ShouldCutLastBlueWireIfHaveMoreThanOneBlueWire(string colors, int position)
        {
            //Arrange
            var wireModule = WireModuleBuilder.New().WithColors(colors).Build();

            //Act
            var message = _service.CutWire(wireModule);

            //Assert
            Assert.Equal(string.Format(Message.WireModuleMessages.CutCustomWire, position), message);
        }
    }
}
