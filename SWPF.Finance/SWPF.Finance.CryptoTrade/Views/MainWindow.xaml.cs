using Prism.Regions;
using System.Windows;

namespace SWPF.Finance.CryptoTrade
{
    /// <summary>
    /// Interaction logic for ViewA.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManager;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IRegionManager regionManager)
        {
            InitializeComponent();
            _regionManager = regionManager;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
     
        }
    }
}
