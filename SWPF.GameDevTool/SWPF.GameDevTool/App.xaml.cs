using System;
using System.Windows;
using Prism.Ioc;

namespace SWPF.GameDevTool
{
    public partial class App
    {
        protected override Window CreateShell()
        {
            Activator.CreateInstanceFrom(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SWPF.GameDevTool.MAIN.DLL"), "SWPF.GameDevTool.MAIN.AppMain");
            return null; // return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}
