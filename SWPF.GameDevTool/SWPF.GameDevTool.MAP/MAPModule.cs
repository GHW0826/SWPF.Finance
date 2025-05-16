using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.GameDevTool.MAP.ViewModels;
using SWPF.GameDevTool.MAP.Views;

namespace Module1
{
    public class MAPModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public MAPModule(IRegionManager regionManager)
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