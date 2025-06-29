using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace SWPF.Common.Base
{
    public class RibbonButtonModel
    {
        public string Label { get; set; }
        public ICommand Command { get; set; }
    }

    public class RibbonGroupModel
    {
        public string Header { get; set; }
        public ObservableCollection<RibbonButtonModel> Buttons { get; set; }
    }

    public class RibbonTabModel
    {
        public string Header { get; set; }
        public ObservableCollection<RibbonGroupModel> Groups { get; set; }
    }

    public class WindowBase : Window
    {
        private void RibbonWindowBase_Loaded(object sender, RoutedEventArgs e)
        {
        }

        public void SetSeparatorVisiblity()
        {
            // RibbonWindow [App > Tab > Group > Button] 순서.
            // 각 APp에는 여러 개의 Tab, Tab은 Group, Group은 Separator가 존재.
        }
    }
}
