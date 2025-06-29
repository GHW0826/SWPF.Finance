using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Prism.Commands;
using Prism.Services.Dialogs;
using SWPF.Finance.Product.popup.Views;
using System;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace SWPF.Finance.Product.popup.ViewModels
{
    public class CategoryItem
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public partial class PR_TemProdCategoriesViewModel : ObservableObject
    {
        public ObservableCollection<CategoryItem> CategoryItems { get; } = new ObservableCollection<CategoryItem>();

        public event EventHandler<ItemSelectedEventArgs> ItemSelected;


        public ICommand RowDoubleClickCommand { get; }
        public ICommand SelectionChangedCommand { get; }
        public ICommand IsVisibleChangedCommand { get; }
        public ICommand LoadingRowCommand { get; }

        public PR_TemProdCategoriesViewModel()
        {
            RowDoubleClickCommand = new RelayCommand<object>(OnRowDoubleClick);
            SelectionChangedCommand = new RelayCommand<object>(OnSelectionChanged);
            IsVisibleChangedCommand = new RelayCommand<object>(OnIsVisibleChanged);
            LoadingRowCommand = new RelayCommand<DataGridRow>(OnLoadingRow);

            LoadInstrumentCategories();
        }

        public void LoadInstrumentCategories()
        {
            CategoryItems.Add(new CategoryItem { Name = "금융상품", Value = "FX" });
            CategoryItems.Add(new CategoryItem { Name = "파생상품", Value = "IRS" });
        }



        private void OnRowDoubleClick(object obj)
        {
            // 처리 로직
            // 항목 더블 클릭 선택
            var selected = obj as CategoryItem;

            // 선택된 항목 (Ex: FI-FWD_BFD_Main) 불러오기
            if (selected != null)
            {
                ItemSelected?.Invoke(this, new ItemSelectedEventArgs { SelectedKey = selected.Value });
            }
        }


        private void OnSelectionChanged(object obj)
        {
            // 처리 로직
            int i = 0;
            i += 1;
        }

        private void OnIsVisibleChanged(object param)
        {
            int i = 0;
            i += 1;
        }
        private void OnLoadingRow(DataGridRow row)
        {
            // 예: Row 색상 또는 상태 지정
            var item = row.Item;
            // 처리 로직
        }
    }
}
