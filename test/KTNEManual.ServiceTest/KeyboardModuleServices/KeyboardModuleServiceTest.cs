using KTNEManual.Domain._Base;
using KTNEManual.Service.KeyboardModuleServices;

namespace KTNEManual.ServiceTest.KeyboardModuleServices
{
    public class KeyboardModuleServiceTest
    {
        [Fact]
        public void ShouldReturnMessageThatIsNotPossibleToImplementThisModuleBecauseOfImages()
        {
            //Arrange
            var service = new KeyboardModuleService();

            //Act
            string message = service.ReturnMessage();

            //Assert
            Assert.Equal(Message.KeyboardModuleMessages.ImpossibleToImplement, message);
        }
    }
}
