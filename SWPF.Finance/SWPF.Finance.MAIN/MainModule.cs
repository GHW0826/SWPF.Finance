using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.Finance.Common.Service.Auth;
using SWPF.Finance.MAIN.Service.LoginPanel;
using SWPF.Finance.MAIN.ViewModels;
using SWPF.Finance.MAIN.Views;

namespace SWPF.Finance.MAIN
{
    public class MainModule : IModule
    {
        private IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
            _regionManager.RequestNavigate("ContentRegion", nameof(LoginPanel));
        }


        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Navigation도 가능하게 등록
            containerRegistry.Register<ILoginPanelService, LoginPanelService>();
            containerRegistry.RegisterForNavigation<LoginPanel, LoginPanelViewModel>();
            containerRegistry.RegisterForNavigation<LobbyPanel, LobbyPanelViewModel>();
        }
    }
}