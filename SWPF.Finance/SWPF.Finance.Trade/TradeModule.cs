using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace SWPF.Finance.Trade
{
    public class TradeModule : IModule
    {
        private IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}