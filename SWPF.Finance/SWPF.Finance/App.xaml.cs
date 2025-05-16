using System;
using System.Windows;
using Prism.Ioc;

namespace SWPF.GameDevTool
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            Activator.CreateInstanceFrom(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SWPF.Finance.MAIN.DLL"), "SWPF.Finance.MAIN.AppMain");
            return null; // return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
