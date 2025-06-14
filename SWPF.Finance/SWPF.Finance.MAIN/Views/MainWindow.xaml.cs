using Prism.Regions;
using SWPF.Common.Base;
using SWPF.Common.Converters;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWPF.Finance.MAIN.Views
{
    public partial class MainWindow : WindowBase
    {
        private readonly IRegionManager _regionManager;


        public bool _isTextVisible;
        public bool IsTextVisible {get; set;}

        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        void appBtn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null) // && pnlIcons.IsEditMode() == false)
            {
                object sysMenuMsg = btn.Tag; //as SysMenuMsg;
                if (sysMenuMsg != null)
                {
                    this.ExecuteSelectedMenu(sysMenuMsg);	// 메뉴와 연결된 윈도우 실행.
                }
            }
        }
        private Window ExecuteSelectedMenu(object sysMenuMsg)
        {
            try
            {
                //// 오픈 가능한 최대 윈도우 수 체크
                //int maxWindowCount = int.Parse(ConfigurationManager.AppSettings["MaxWindowCount"]);
                //if (Application.Current.Windows.Count - 2 == maxWindowCount)
                //{
                //    return null;
                //}
                string toolType = sysMenuMsg as string;

                Window childWindow = DynamicLoader.CreateInstance<Window>(toolType /* sysMenuMsg.MenuExecCd */, "MainWindow");
                childWindow.Height = 600;
                childWindow.Width = 1024;
                if (childWindow == null)
                    return null;

                childWindow.Show();

                return childWindow;
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
