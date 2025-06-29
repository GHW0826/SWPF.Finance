using SWPF.Common.Base;
using SWPF.Finance.Product.popup.ViewModels;
using System;
using System.Windows;

namespace SWPF.Finance.Product.popup.Views
{

    public enum ProductSect { Template, Product }

    public class ItemSelectedEventArgs : EventArgs
    {
        public string SelectedKey { get; set; }
    }

    public partial class PR_TemProdCategories : UserControlBase
    {
        public delegate void ItemSelectedEvent(object sender, ItemSelectedEventArgs e);

        public event ItemSelectedEvent ItemSelected;

        public PR_TemProdCategories()
        {
            InitializeComponent();
            this.Loaded += PR_TemProdCategories_Loaded;
        }

        private void PR_TemProdCategories_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is PR_TemProdCategoriesViewModel vm)
            {
                vm.ItemSelected -= Vm_ItemSelected;
                vm.ItemSelected += Vm_ItemSelected;
            }
        }

        private void Vm_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            // 뷰에서 이벤트 다시 발생
            ItemSelected?.Invoke(this, e);
        }
    }
}
