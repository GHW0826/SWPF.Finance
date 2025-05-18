using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.Finance.CryptoTrade.ViewModels;
using SWPF.Finance.CryptoTrade.Views;

namespace SWPF.Finance.CryptoTrade
{
    public class CryptoTradeModule : IModule
    {
        private IRegionManager _regionManager;


        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainView));
        }


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigation도 가능하게 등록
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
        }
    }
}