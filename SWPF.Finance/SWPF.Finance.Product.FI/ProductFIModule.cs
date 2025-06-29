using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.Finance.Product.FI;
using SWPF.Finance.Product.ViewModels;

namespace SWPF.Finance.Product
{
    public class ProductFIModule : IModule
    {
        private IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();

            containerRegistry.RegisterDialog<FI_FWD_BFD_Main, FI_FWD_BFD_MainViewModel>();
        }
    }
}