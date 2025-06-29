using CommunityToolkit.Mvvm.ComponentModel;
using DryIoc;
using Prism.Commands;
using Prism.Services.Dialogs;
using System;
using System.Windows.Input;

namespace SWPF.Finance.Product.FI
{
    public partial class FI_FWD_BFD_MainViewModel : ObservableObject, IDialogAware
    {
        public string Title => "Fixed Income - Forward - Bond Foward";

        public event Action<IDialogResult> RequestClose;
        public bool CanCloseDialog() => true;


        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public FI_FWD_BFD_MainViewModel()
        {

            SaveCommand = new DelegateCommand(OnSave);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }


        private void OnSave()
        {
            // Setup logic
        }

        private void OnCancel()
        {
            // Login logic
        }
    }
}
