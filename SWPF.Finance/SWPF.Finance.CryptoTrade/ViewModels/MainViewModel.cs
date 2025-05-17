
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;
using Prism.Mvvm;
using SWPF.Finance.Common.Chart;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace SWPF.Finance.CryptoTrade.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IChartService _chartService;
        public ObservableCollection<FinancialPoint> ChartData { get; set; }
        public ICommand AddDataCommand { get; }


        public MainViewModel()
        {
            _chartService = new CryptoChartService();
            ChartData = new ObservableCollection<FinancialPoint>();
            AddDataCommand = new DelegateCommand(AddData);

            InitializeChart();
        }
        private void InitializeChart()
        {
            _chartService.InitializeChart();
            ChartData.Clear();
            RaisePropertyChanged(nameof(ChartData)); // Prism의 RaisePropertyChanged
        }

        private void AddData()
        {
            if (_chartService == null) return;

            var random = new Random();
            double time = ChartData.Count + 1;
            double open = random.NextDouble() * 1000;
            double high = open + random.NextDouble() * 100;
            double low = open - random.NextDouble() * 100;
            double close = random.NextDouble() * 1000;

            _chartService.AddDataPoint(time, open, high, low, close);
            RefreshChartData();
        }

        private void RefreshChartData()
        {
            ChartData.Clear();
            foreach (var data in _chartService.GetChartData())
            {
                if (data is FinancialPoint point)
                    ChartData.Add(point);
            }
        }
    }
}
