using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SWPF.Finance.Product.popup.Views;
using SWPF.Finance.Product.popup.ViewModels;
using SWPF.Finance.Product.ViewModels;

namespace SWPF.Finance.Product
{
    public class ProductModule : IModule
    {
        private IRegionManager _regionManager;

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager = containerProvider.Resolve<IRegionManager>();
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MainWindow, MainWindowViewModel>();
            containerRegistry.RegisterForNavigation<PR_TemProdCategories, PR_TemProdCategoriesViewModel>();

            containerRegistry.RegisterDialog<PR_TemplateNewOpen, PR_TemplateNewOpenViewModel>();
        }
    }
}