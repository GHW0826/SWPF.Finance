using SWPF.Common.Base;
using SWPF.Finance.Product.popup.ViewModels;

namespace SWPF.Finance.Product.popup.Views
{
    public partial class PR_TemplateNewOpen : UserControlBase
    {
        public PR_TemplateNewOpen()
        {
            InitializeComponent();
        }

        private void PRCateg_Tem_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            if (this.DataContext is PR_TemplateNewOpenViewModel vm)
                vm.OnTemplateItemSelected(sender, e);
        }

        private void PRCateg_Prod_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            if (this.DataContext is PR_TemplateNewOpenViewModel vm)
                vm.OnProductItemSelected(sender, e);
        }
    }
}
