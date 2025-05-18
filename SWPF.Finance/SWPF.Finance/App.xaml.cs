using System;
using System.Windows;
using Prism.DryIoc;
using Prism.Ioc;
using Prism.Modularity;
using SWPF.Finance.CryptoTrade;

namespace SWPF.GameDevTool
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            Activator.CreateInstanceFrom(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SWPF.Finance.MAIN.DLL"), "SWPF.Finance.MAIN.AppMain");
            return null; // return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            // CryptoTrade 모듈 자동 등록
            moduleCatalog.AddModule<CryptoTradeModule>();
        }
    }
}
