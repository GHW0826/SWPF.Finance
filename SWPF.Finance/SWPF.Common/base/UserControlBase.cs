using System.Windows;
using System.Windows.Controls;

namespace SWPF.Common.Base
{
    public class UserControlBase : UserControl
    {
        // public ForegroundManager ForegroundManager { get; set; }

        public Window HostWindow { get; set; }

        public string Title { get; set; }
    }
}
