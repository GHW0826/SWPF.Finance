using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;
using Prism.Services.Dialogs;
using SWPF.Finance.Product.FI;
using SWPF.Finance.Product.popup.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SWPF.Finance.Product.popup.ViewModels
{
    public class DetailItem
    {
        public string Name { get; set; }
    }

    public partial class PR_TemplateNewOpenViewModel : ObservableObject, IDialogAware
    {
        public DetailItem SelectedDetailItem { get; set; }
        private string _nextDialogKey;


        public ICommand DetailItemDoubleClickCommand { get; }

        private readonly IDialogService _dialogService;



        public string Title => "템플릿 신규";

        public event Action<IDialogResult> RequestClose;
        public bool CanCloseDialog() => true;

        public ObservableCollection<DetailItem> DetailItems { get; } = new ObservableCollection<DetailItem>
        {
            new DetailItem { Name = "New Blank" }
        };

        public ICommand ConfirmCommand { get; }
        public ICommand TemplateSourceSelectCommand { get; }
        public ICommand ProductSourceSelectCommand { get; }

        public PR_TemplateNewOpenViewModel(IDialogService dialogService)
        {
            TemplateSourceSelectCommand = new DelegateCommand(OnTemplateSourceSelect);
            ProductSourceSelectCommand = new DelegateCommand(OnProductSourceSelect);
            ConfirmCommand = new DelegateCommand(() =>
            {
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            });
            _dialogService = dialogService;

            DetailItemDoubleClickCommand = new RelayCommand(OnDetailItemDoubleClick);

            // 디폴트 항목 추가
            DetailItems.Add(new DetailItem { Name = "New Blank" });
        }
        private void OnDetailItemDoubleClick()
        {
            if (SelectedDetailItem == null) 
                return;


            // 현재 다이얼로그 닫기
            _nextDialogKey = SelectedDetailItem.Name;
            RequestClose?.Invoke(new DialogResult(ButtonResult.None));

        }

        public void OnTemplateItemSelected(object sender, ItemSelectedEventArgs e)
        {
            // 예: 선택된 항목 키를 기반으로 상세 데이터 조회
            LoadItemDetailsByKey(e.SelectedKey);
        }

        private async void LoadItemDetailsByKey(string key)
        {
            DetailItems.Clear();
            DetailItems.Add(new DetailItem { Name = "New Blank" });

            var result = await Task.Run(() => FakeServerFetch(key));
            foreach (var line in result)
                DetailItems.Add(new DetailItem { Name = line });
        }

        private List<string> FakeServerFetch(string key)
        {
            Thread.Sleep(500); // 지연 시뮬레이션

            List<string> result = new List<string>();

            switch (key)
            {
                case "FX":
                    result.Add("상품코드: FX123");
                    result.Add("기초자산: USD/KRW");
                    result.Add("만기일자: 2026-01-01");
                    break;

                case "IRS":
                    result.Add("상품코드: IRS456");
                    result.Add("기초자산: 금리스왑");
                    result.Add("만기일자: 2027-12-31");
                    break;

                default:
                    result.Add($"[{key}] 항목에 대한 상세 정보를 찾을 수 없습니다.");
                    break;
            }

            return result;
        }


        public void OnDialogClosed() 
        {

            if (string.IsNullOrEmpty(_nextDialogKey))
                return;

            var p = new DialogParameters
            {
                { "SelectedName", _nextDialogKey }
            };

            _dialogService.ShowDialog(nameof(FI_FWD_BFD_Main), p, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    // 결과 처리
                }
            });

            _nextDialogKey = null; // 재진입 방지
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        private void OnTemplateSourceSelect()
        {
            // 템플릿 소스 선택 로직
            int i = 0;
            i += 1;
        }

        private void OnProductSourceSelect()
        {
            // 템플릿 소스 선택 로직
            int i = 0;
            i += 1;
        }

        public void OnProductItemSelected(object sender, ItemSelectedEventArgs e)
        {
            int i = 0;
            i += 1;
        }
    }
}
