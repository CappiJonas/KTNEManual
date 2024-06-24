using KTNEManual.Service.ButtonModuleServices;
using KTNEManual.ServiceTest._Builders;

namespace KTNEManual.ServiceTest.ButtonModuleServices
{
    public class PressButtonServiceTest
    {
        private readonly PressButtonService _pressButtonService;

        public PressButtonServiceTest()
        {
            _pressButtonService = new PressButtonService();
        }

        [Theory]
        [InlineData("azul", "Abortar")]
        [InlineData("branco", "Abortar", 0, true)]
        [InlineData("amarelo", "Segure")]
        public void ShouldNotPressAndReleaseButtonWithThisParams(string buttonColor, string buttonText, int numberOfBatteries = 0,
                                                                    bool isIndicatorOnCAR = false, bool isIndicatorOnFRK = false)
        {
            //Arrange
            var buttonModule = ButtonModuleBuilder.New().WithButtonColor(buttonColor).WithButtonText(buttonText).Build();

            //Act
            var result = _pressButtonService.ShouldPressAndRelease(buttonModule, numberOfBatteries, isIndicatorOnCAR, isIndicatorOnFRK);

            //Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData("amarelo", "Detonar", 2)]
        [InlineData("azul", "Segure", 3, false, true)]
        [InlineData("vermelho", "Segure")]
        public void ShouldPressAndReleaseButtonWithThisParams(string buttonColor, string buttonText, int numberOfBatteries = 0, 
                                                                bool isIndicatorOnCAR = false, bool isIndicatorOnFRK = false)
        {
            //Arrange
            var buttonModule = ButtonModuleBuilder.New().WithButtonColor(buttonColor).WithButtonText(buttonText).Build();

            //Act
            var result = _pressButtonService.ShouldPressAndRelease(buttonModule, numberOfBatteries, isIndicatorOnCAR, isIndicatorOnFRK);

            //Assert
            Assert.True(result);
        }
    }
}
