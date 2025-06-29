using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using SWPF.Common.Network.Http;
using SWPF.Finance.Booking;
using SWPF.Finance.Common;
using SWPF.Finance.Common.Service.Auth;
using SWPF.Finance.MAIN;
using SWPF.Finance.Product;
using SWPF.Finance.Test;
using SWPF.Finance.Trade;
using System.Windows;

namespace SWPF.Finance
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<SWPF.Finance.MAIN.MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IHttpClient, DefaultHttpClient>();
            containerRegistry.Register<IAuthService, AuthService>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<FinanceCommonModule>();
            moduleCatalog.AddModule<MainModule>();
            moduleCatalog.AddModule<BookingModule>();
            moduleCatalog.AddModule<ProductModule>();
            moduleCatalog.AddModule<ProductFIModule>();
            moduleCatalog.AddModule<TradeModule>();
            moduleCatalog.AddModule<TestModule>();
        }
    }
}
