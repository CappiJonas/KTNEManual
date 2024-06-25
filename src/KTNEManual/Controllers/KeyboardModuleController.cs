using KTNEManual.Service.KeyboardModuleServices;
using System.ComponentModel.DataAnnotations;

namespace KTNEManual.Controllers
{
    public class KeyboardModuleController
    {
        public void ShowMessage()
        {
            var service = new KeyboardModuleService();
            string message = service.ReturnMessage();
            Console.WriteLine(message);
        }
    }
}
