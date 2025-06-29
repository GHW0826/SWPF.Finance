using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.Finance.Common.ViewModels;

namespace SWPF.Finance.Common
{
    public class FinanceCommonModule : IModule
    {
        private IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
        }


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigation도 가능하게 등록
            containerRegistry.RegisterForNavigation<HostWindow, HostWindowViewModel>();

        }
    }
}