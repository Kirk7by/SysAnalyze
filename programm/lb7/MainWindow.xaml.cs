using lb7.страницы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
namespace lb7
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Перейти_путевые_Click(object sender, RoutedEventArgs e)
        {
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();          
            фрейм.Source = new Uri("страницы/Page1.xaml", UriKind.Relative);
        }

        private void Перейти_отчеты_Click(object sender, RoutedEventArgs e)
        {
           
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();
            фрейм.Source = new Uri("страницы/Page2.xaml", UriKind.Relative);
        }

        private void Перейти_водители_Click(object sender, RoutedEventArgs e)
        {
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();
            фрейм.Source = new Uri("страницы/Page3.xaml", UriKind.Relative);
        }

        private void Перейти_авто_Click(object sender, RoutedEventArgs e)
        {
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();
            фрейм.Source = new Uri("страницы/Page4.xaml", UriKind.Relative);
        }
    }
}
