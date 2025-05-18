using CommunityToolkit.Mvvm.Input;
using LiveCharts;
using LiveCharts.Wpf;
using LiveChartsCore;
using LiveChartsCore.Geo;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace SWPF.Finance.CryptoTrade.Views
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : UserControl
    {
        private Point? _lastMousePosition;
        private bool _isDragging = false;
        public IRelayCommand AddDataCommand { get; }

        public MainView()
        {
            InitializeComponent();
            this.DataContext = this;
            AddDataCommand = new RelayCommand(AddData);
            foreach (var axis in CryptoChart.XAxes)
            {
                axis.MinLimit = 0;
                axis.MaxLimit = 10;
            }

            foreach (var axis in CryptoChart.YAxes)
            {
                axis.MinLimit = 0;
                axis.MaxLimit = 1000;
            }
        }

        public ISeries[] Series { get; set; }
         = new ISeries[]
         {
                new LineSeries<int>
                {
                    Values = new int[] { 4, 6, 5, 3, -3, -1, 2 }
                },
                new ColumnSeries<double>
                {
                    Values = new double[] { 2, 5, 4, -2, 4, -3, 5 }
                }
         };

        private void AddData()
        {
            foreach (var axis in CryptoChart.YAxes)
            {
                axis.MinLimit = 0;
                axis.MaxLimit = 100;
            }
        }

        private void CryptoChart_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl))
            {
                // Ctrl + 휠 -> Y축 확대/축소
                foreach (var axis in CryptoChart.YAxes)
                {
                    axis.MinLimit += e.Delta > 0 ? 10 : -10;
                    axis.MaxLimit -= e.Delta > 0 ? 10 : -10;
                }
            }
            else
            {
                // 기본 휠 -> X축 확대/축소
                foreach (var axis in CryptoChart.XAxes)
                {
                    axis.MinLimit += e.Delta > 0 ? 1 : -1;
                    axis.MaxLimit -= e.Delta > 0 ? 1 : -1;
                }
            }
        }

        private void CryptoChart_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _lastMousePosition = e.GetPosition(this);
            _isDragging = true;
            this.CaptureMouse(); // 마우스 캡처
        }

        private void CryptoChart_MouseMove(object sender, MouseEventArgs e)
        {
            e.Handled = true;

            if (_isDragging && _lastMousePosition.HasValue)
            {
                var currentPosition = e.GetPosition(this);
                double deltaX = currentPosition.X - _lastMousePosition.Value.X;
                double deltaY = currentPosition.Y - _lastMousePosition.Value.Y;

                foreach (var axis in CryptoChart.XAxes)
                {
                    axis.MinLimit -= deltaX / 5;
                    axis.MaxLimit -= deltaX / 5;
                }

                foreach (var axis in CryptoChart.YAxes)
                {
                    axis.MinLimit += deltaY / 5;
                    axis.MaxLimit += deltaY / 5;
                }

                _lastMousePosition = currentPosition; 
            }
        }
        private void CryptoChart_LostMouseCapture(object sender, MouseEventArgs e)
        {
            _isDragging = false;
            _lastMousePosition = null;
        }
        private void CryptoChart_MouseUp(object sender, MouseButtonEventArgs e)
        {
            _lastMousePosition = null;
            this.ReleaseMouseCapture();
        }
    }
}
