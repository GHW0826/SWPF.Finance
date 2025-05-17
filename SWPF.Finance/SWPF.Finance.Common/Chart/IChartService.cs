using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWPF.Finance.Common.Chart
{
    public interface IChartService
    {
        // 차트 초기화
        void InitializeChart();
        // 차트에 새로운 데이터 포인트 추가 (봉 차트 기준)
        void AddDataPoint(double time, double open, double high, double low, double close);
        // 차트 데이터 초기화
        void ClearData();
        // 차트 데이터 가져오기 (뷰에서 사용)
        IEnumerable<FinancialPoint> GetChartData();
    }
}
