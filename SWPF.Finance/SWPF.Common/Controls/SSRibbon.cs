using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Ribbon;
using System.Windows.Markup;

namespace SWPF.Common.Controls
{

    [ContentProperty("Items")]
    public class SSRibbon : Control
    {
        static SSRibbon()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SSRibbon), new FrameworkPropertyMetadata(typeof(SSRibbon)));
        }

        public SSRibbon()
        {
            Items = new ObservableCollection<RibbonTab>();
        }

        public ObservableCollection<RibbonTab> Items { get; }

        private Ribbon _ribbon;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _ribbon = GetTemplateChild("PART_Ribbon") as Ribbon;
            if (_ribbon != null)
            {
                _ribbon.Items.Clear();
                foreach (var item in Items)
                {
                    _ribbon.Items.Add(item);
                }

                // 컬렉션 변경시 바로 반영
                Items.CollectionChanged += (s, e) =>
                {
                    _ribbon.Items.Clear();
                    foreach (var tab in Items)
                        _ribbon.Items.Add(tab);
                };
            }
        }
    }
}
