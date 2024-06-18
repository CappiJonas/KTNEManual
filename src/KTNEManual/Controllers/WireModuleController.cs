using KTNEManual.Service.Strategies.WireModuleStrategies;

namespace KTNEManual.Controllers
{
    public class WireModuleController
    {
        public void SetWireModule()
        {
            var context = new WireModuleContext();
            context.ShowWhatWireToCut();
        }
    }
}
