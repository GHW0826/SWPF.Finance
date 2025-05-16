using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SWPF.Finance.MAIN.Views
{
    /// <summary>
    /// LobbyPanel.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LobbyPanel : UserControl
    {
        public event EventHandler AppBtnClick;

        public LobbyPanel()
        {
            InitializeComponent();
            InitMenuControl();
        }
        private void InitMenuControl()
        {

            var launcherGrid = new UniformGrid
            {
                Rows = 2,
                Columns = 2,
                Margin = new Thickness(10),
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };

            // 앱 정보 리스트
            var apps = new[]
            {
                new { Title = "Map", Tag = "MAP" },
                new { Title = "Skill", Tag = "SKILL" },
                new { Title = "Editor", Tag = "EDITOR" },
                new { Title = "TEST", Tag = "TEST" },
            };

            foreach (var app in apps)
            {
                var btn = new Button
                {
                    Margin = new Thickness(12),
                    Tag = app.Tag,
                    Padding = new Thickness(4),
                    Width = 96,
                    Height = 96,
                    Content = new StackPanel
                    {
                        Orientation = Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        Children =
                        {
                            // TODO Image
                            new Rectangle
                            {
                                Width = 36,
                                Height = 36,
                                Fill = Brushes.LightGray,
                                Margin = new Thickness(0, 0, 0, 6)
                            },
                            new TextBlock
                            {
                                Text = app.Title,
                                FontWeight = FontWeights.SemiBold,
                                FontSize = 12,
                                HorizontalAlignment = HorizontalAlignment.Center
                            }
                        }
                    }
                };
                btn.Click += (s, e) => AppBtnClick?.Invoke(s, e);
                launcherGrid.Children.Add(btn);
            }

            gdMainMenu.Children.Add(launcherGrid);
        }

        private StackPanel NewIconPanel()
        {
            return new StackPanel()
            {
                Height = 86,
                Width = 58,
                Margin = new Thickness(0, 12, 0, 0),
                HorizontalAlignment = HorizontalAlignment.Center,
                Tag = "IconPanel"
            };
        }
    }
}
