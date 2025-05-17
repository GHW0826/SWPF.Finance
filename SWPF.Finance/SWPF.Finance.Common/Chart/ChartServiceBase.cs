using System.Collections.Generic;

namespace SWPF.Finance.Common.Chart
{
    /*
        ChartServiceBase는 공통 차트 로직을 제공.
        데이터 포인트 저장과 초기화, 조회 기능은 공통으로 처리.
        이 기본 클래스는 주식과 암호화폐에서 공통으로 사용 가능.
    */
    public abstract class ChartServiceBase : IChartService
    {
        protected List<FinancialPoint> _dataPoints = new List<FinancialPoint>();

        public virtual void InitializeChart()
        {
            _dataPoints.Clear();
        }

        public virtual void AddDataPoint(double time, double open, double high, double low, double close)
        {
            _dataPoints.Add(new FinancialPoint(time, open, high, low, close));
        }

        public virtual void ClearData()
        {
            _dataPoints.Clear();
        }

        public virtual IEnumerable<FinancialPoint> GetChartData()
        {
            return _dataPoints;
        }
    }

    // FinancialPoint 구조체 (봉 차트에서 사용)
    public struct FinancialPoint
    {
        public double Time { get; }
        public double Open { get; }
        public double High { get; }
        public double Low { get; }
        public double Close { get; }

        public FinancialPoint(double time, double open, double high, double low, double close)
        {
            Time = time;
            Open = open;
            High = high;
            Low = low;
            Close = close;
        }
    }
}
