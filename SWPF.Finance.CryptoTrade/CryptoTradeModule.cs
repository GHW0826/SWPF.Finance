using Prism.Ioc;
using Prism.Modularity;
using SWPF.Finance.CryptoTrade.ViewModels;
using SWPF.Finance.CryptoTrade.Views;

namespace Module1
{
    public class CryptoTradeModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public CryptoTradeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            // Navigation용으로 View 등록
            _regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigation도 가능하게 등록
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
        }
    }
}