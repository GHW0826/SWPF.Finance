﻿using SWPF.Finance.MAIN.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWPF.Finance.MAIN.Views
{
    /// <summary>
	/// 인스턴스를 동적으로 로드하는 클래스
	/// </summary>
	public static class DynamicLoader
    {
        /// <summary>
        /// 업무별 애플리케이션 어셈블리에 포함된 클래스의 인스턴스를 로딩한다.
        /// </summary>
        /// <typeparam name="T">제네릭 개체 형식</typeparam>
        /// <param name="appSubName">애플리케이션 약어(PR, PR.EQ, PR.FI, UC ...)</param>
        /// <param name="className">클래스 명</param>
        /// <returns>생성된 인스턴스</returns>
        public static T CreateInstance<T>(string appSubName, string className)
        {
            string assemblyUrl = string.Format("SWPF.Finance.{0}.DLL", appSubName);
            string typeName = string.Format("SWPF.Finance.{0}.{1}", appSubName, className);

            Uri uri = new Uri(assemblyUrl, UriKind.RelativeOrAbsolute);
            // 상대 경로라면 절대 경로로 바꾼다.
            if (uri.IsAbsoluteUri == false)
            {
                assemblyUrl = AppDomain.CurrentDomain.BaseDirectory + assemblyUrl;
            }

            try
            {
                ObjectHandle objectHandle = Activator.CreateInstanceFrom(assemblyUrl, typeName);
                return (T)objectHandle.Unwrap();
            }
            catch (FileNotFoundException fnfEx)
            {
                // CM_007: 파일({0})을 찾을 수 없습니다.\r\n{1}
                return default(T);
            }
            catch (TypeLoadException tlEx)
            {
                return default(T);
            }
        }
    }

    /// <summary>
    /// LobbyPanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LobbyPanel : UserControl
    {
        public LobbyPanel()
        {
            InitializeComponent();
            var vm = DataContext as LobbyPanelViewModel;
            vm.AppSelected += toolType =>
            {
                ExecuteSelectedMenu(toolType);
            };
        }

        private Window ExecuteSelectedMenu(string toolType)
        {
            try
            {
                Window childWindow = DynamicLoader.CreateInstance<Window>(toolType, "MainWindow");
                if (childWindow == null)
                    return null;

                childWindow.Height = 600;
                childWindow.Width = 1024;
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
