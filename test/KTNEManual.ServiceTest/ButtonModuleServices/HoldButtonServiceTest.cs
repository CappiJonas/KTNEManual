using KTNEManual.Domain._Base;
using KTNEManual.Domain.ButtonModules;
using KTNEManual.Service.ButtonModuleServices;
using KTNEManual.ServiceTest._Builders;

namespace KTNEManual.ServiceTest.ButtonModuleServices
{
    public class HoldButtonServiceTest
    {
        private readonly ButtonModule _buttonModule;
        private readonly HoldButtonService _service;

        public HoldButtonServiceTest()
        {
            _buttonModule = ButtonModuleBuilder.New().Build();
            _service = new HoldButtonService();
        }

        [Theory]
        [InlineData("azul", "4")]
        [InlineData("branco", "1")]
        [InlineData("amarelo", "5")]
        [InlineData("vermelho", "1")]
        [InlineData("preto", "1")]
        public void ShouldReleaseButtonWhenSpecificNumberWithSpecificBandColor(string bandColor, string numberExpected)
        {
            //Arrange
            //Act
            var message = _service.ReleasePressingButton(_buttonModule, bandColor);

            //Assert
            Assert.Contains(numberExpected, message);
        }
    }
}
