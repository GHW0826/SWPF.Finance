﻿
namespace SWPF.Finance.StockTrade.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public MainViewModel()
        {
            Message = "View A from your Prism Module";
        }
    }
}
