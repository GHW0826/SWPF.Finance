using SWPF.Common.Base;
using SWPF.Finance.Common.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SWPF.Finance.Common
{
    /// <summary>
    /// HostWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class HostWindow : WindowBase
    {
        public HostWindow()
        {
            InitializeComponent();

        }

        /*
        public HostWindow(UserControlBase usercontrol, Window parent) 
            : this()
        {

            this.Owner = parent;
            this.bdCenter.Child = usercontrol;
            usercontrol.HostWindow = this;

            // if (usercontrol.ForegroundManager == null)
            //    usercontrol.ForegroundManager = new ForegroundManager(usercontrol);
            if (!string.IsNullOrEmpty(usercontrol.Title))
                this.Title = usercontrol.Title;

            if (usercontrol.DataContext is HostWindowViewModel vm)
            {
                vm.RequestClose += () => this.Close(); // ViewModel이 요청 시 View가 닫음
            }
        }

        public HostWindow(UserControlBase usercontrol, Visual parent) 
            : this(usercontrol, Window.GetWindow(parent)) 
        { }
        */

        /*
        public bool? ShowHostWindow()
        {
            this.Show(); // 창 비동기 표시

            // 부모 창 비활성화
            IntPtr handle = (new System.Windows.Interop.WindowInteropHelper(this.Owner)).Handle;
            EnableWindow(handle, false);

            // DispatcherFrame 사용: 메시지 루프를 하나 더 만들어 현재 스레드 "정지 대기"
            this.InnerDispatcherFrame = new DispatcherFrame();
            Dispatcher.PushFrame(this.InnerDispatcherFrame); // 여기서 창 닫힐 때까지 block

            // 창이 닫히면 다시 부모창 활성화
            EnableWindow(handle, true);
            this.Owner.Activate();

            return this.HostWindowResult; // 창이 닫힌 후 결과 반환
        }

        public bool ShowModal(Window windowBase)
        {
            // 위의 창 띄우기 호출
            this.ShowHostWindow();
            return (this.Tag as bool?) ?? false; // Tag로 값 전달받음 (별로 추천되진 않음)
        }
        */
    }
}
