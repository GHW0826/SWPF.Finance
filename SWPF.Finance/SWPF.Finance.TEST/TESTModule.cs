using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.Finance.TEST.ViewModels;
using SWPF.Finance.TEST.Views;
namespace Module1
{
    public class TESTModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public TESTModule(IRegionManager regionManager)
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