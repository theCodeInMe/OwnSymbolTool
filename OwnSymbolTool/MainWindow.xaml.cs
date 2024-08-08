using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OwnSymbolTool
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            fontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
        }

        private void closeApp(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void onFontChanged(object sender, SelectionChangedEventArgs e)
        {
            showFont((FontFamily)fontList.SelectedItem);
        }

        private void onFontSizeChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
        }

        private void showFont(FontFamily fontFamily)
        {
            wrapPanel.Children.Clear();

            int from = int.Parse(fromUnicode.Text);
            int to = int.Parse(toUnicode.Text);

            for (int i = from; i <= to; i++)
            {
                Button button = new Button()
                {
                    FontFamily = fontFamily,
                    Content = (char)i,
                    BorderBrush = Brushes.Transparent,
                    Background = Brushes.Transparent,
                    Margin = new Thickness(2),
                    ToolTip = $"Unicode: &#x{i:x4} \nDezimal: {i}"

                };

                wrapPanel.Children.Add(button);
            }
        }
    }
}