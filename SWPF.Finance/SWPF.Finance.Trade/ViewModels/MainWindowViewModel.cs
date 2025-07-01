using CommunityToolkit.Mvvm.ComponentModel;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Media;

namespace SWPF.Finance.Trade.ViewModels
{
    public class HogaRow
    {
        public string AskCount { get; set; }
        public string AskVolume { get; set; }
        public string BidCount { get; set; }
        public string BidVolume { get; set; }

        private double _maxCount = 1;
        private double _maxVolume = 1;
        private double _maxWidth = 100;

        public void BindMax(double maxCount, double maxVolume, double maxWidth)
        {
            _maxCount = maxCount;
            _maxVolume = maxVolume;
            _maxWidth = maxWidth;
        }

        public double AskCountBarWidth => Normalize(AskCount, _maxCount);
        public double AskVolumeBarWidth => Normalize(AskVolume, _maxVolume);
        public double BidCountBarWidth => Normalize(BidCount, _maxCount);
        public double BidVolumeBarWidth => Normalize(BidVolume, _maxVolume);

        private double Normalize(string value, double max)
        {
            if (double.TryParse(value, out var v) && max > 0)
                return Math.Min(v / max * _maxWidth, _maxWidth);
            return 0;
        }
    }

    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<HogaRow> HogaRows { get; set; } = new ObservableCollection<HogaRow>();

        public double MaxVolume { get; private set; } = 1; // 나눌 때 0 방지
        public double MaxCount { get; private set; } = 1;

        public const double MaxBarPixel = 120;

        public MainWindowViewModel()
        {
            LoadDummyData();
        }

        public void LoadDummyData()
        {
            var dummy = new[]
            {
            new HogaRow { AskCount = "66", AskVolume = "293.47", BidCount = "44", BidVolume = "282.48" },
            new HogaRow { AskCount = "51", AskVolume = "74.53", BidCount = "20", BidVolume = "181.51" },
            new HogaRow { AskCount = "57", AskVolume = "168.47", BidCount = "81", BidVolume = "63.73" },
            new HogaRow { AskCount = "58", AskVolume = "159.12", BidCount = "92", BidVolume = "137.79" },
            new HogaRow { AskCount = "19", AskVolume = "73.95", BidCount = "93", BidVolume = "203.84" },
            new HogaRow { AskCount = "251", AskVolume = "769.54", BidCount = "330", BidVolume = "869.35" } // 총합
        };

            MaxCount = dummy.SelectMany(r => new[] { r.AskCount, r.BidCount })
                            .Select(s => double.TryParse(s, out var v) ? v : 0)
                            .Max();

            MaxVolume = dummy.SelectMany(r => new[] { r.AskVolume, r.BidVolume })
                             .Select(s => double.TryParse(s, out var v) ? v : 0)
                             .Max();

            HogaRows.Clear();
            foreach (var r in dummy)
            {
                r.BindMax(MaxCount, MaxVolume, MaxBarPixel);
                HogaRows.Add(r);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}