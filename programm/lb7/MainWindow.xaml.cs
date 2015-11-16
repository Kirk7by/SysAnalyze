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
using Configurations;
using Microsoft.Win32;

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
            databaseTextBox.Text = config.Default.connectionsString;
        }
        private void Перейти_путевые_Click(object sender, RoutedEventArgs e)
        {
            generateTextLabelSmiler();
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();          
            фрейм.Source = new Uri("страницы/Page1.xaml", UriKind.Relative);
        }

        private void Перейти_отчеты_Click(object sender, RoutedEventArgs e)
        {
            generateTextLabelSmiler();
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();
            фрейм.Source = new Uri("страницы/Page2.xaml", UriKind.Relative);
        }

        private void Перейти_водители_Click(object sender, RoutedEventArgs e)
        {
            generateTextLabelSmiler();
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();
            фрейм.Source = new Uri("страницы/Page3.xaml", UriKind.Relative);
        }

        private void Перейти_авто_Click(object sender, RoutedEventArgs e)
        {
            generateTextLabelSmiler();
            фрейм.Content = null;
            фрейм.NavigationService.RemoveBackEntry();
            фрейм.Source = new Uri("страницы/Page4.xaml", UriKind.Relative);

        }
        void generateTextLabelSmiler()
        {
            Random rnd= new Random();
            string[] word = new string[] { "Это не должно занять много времени..:)", "Всего лишь подождите пару секунд...  :)", "Ждите...","Еще совсем чуть-чуть","Операция почти завершена...",
            "Мы налаживаем связь..","Загружаем новую локацию","Форма обязательно загрузится, поверьте..."};

            SmileLabel.Content = word[rnd.Next(0, word.Length - 1)];
        }

        private void settings_Click(object sender, RoutedEventArgs e)
        {
        }

        private void settings_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Вы собираетесь изменить строку подключение. Данное дествие может полностью отменить доступ к базе данных и привести к полному прекращению функцианирования программы. Вы точно собираетесь изменить строку подключения?", "Изменение строки подключения(Для опытных)", MessageBoxButton.YesNo, MessageBoxImage.Stop, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                MessageBoxResult result = MessageBox.Show("Вернуть стандартные настройки?", "Изменение строки подключения(Для опытных)", MessageBoxButton.YesNoCancel, MessageBoxImage.Question, MessageBoxResult.Cancel);
                if (result == MessageBoxResult.No)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "mdf File|*.mdf|ALL Files|*. ";
                    openFileDialog1.Title = "Select a Cursor File";

                    if (openFileDialog1.ShowDialog() == true)
                    {
                        databaseTextBox.Text = openFileDialog1.FileName;

                        config.Default.connectionsString = @"(LocalDB)\MSSQLLocalDB; AttachDbFilename =" + openFileDialog1.FileName;
                        config.Default.Save();
                        MessageBox.Show("Чтобы изменения вступили в силу, обновите форму!", "Сохранение строки подключения", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                if (result == MessageBoxResult.Yes)
                {
                    config.Default.connectionsString = @"(LocalDb)\MSSQLLocalDB;Initial Catalog=SysAnalyze;";
                    config.Default.Save();
                    MessageBox.Show("Чтобы изменения вступили в силу, обновите форму!", "Сохранение строки подключения", MessageBoxButton.OK,MessageBoxImage.Information);
                }
            }
            else
            {
                //do yes stuff
            }
        }
    }
}
