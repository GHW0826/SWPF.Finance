using CommunityToolkit.Mvvm.ComponentModel;
using Prism.Commands;
using Prism.Services.Dialogs;
using SWPF.Finance.Product.popup.Views;
using System.Windows.Input;

namespace SWPF.Finance.Product.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private readonly IDialogService _dialogService;
        public ICommand TemplateNewCommand { get; }

        public MainWindowViewModel(IDialogService dialogService)
        {
            _dialogService = dialogService;
            TemplateNewCommand = new DelegateCommand(TemplateNew);
        }

        private void TemplateNew()
        {
            _dialogService.ShowDialog(nameof(PR_TemplateNewOpen), null, result =>
            {
                if (result.Result == ButtonResult.OK)
                {
                    // OK 클릭 시 후처리
                }
            });
        }
    }
}
