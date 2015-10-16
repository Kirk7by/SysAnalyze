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

namespace lb7.страницы
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Отчет_о_работе_тс_Click(object sender, RoutedEventArgs e)
        {
            Отчет_о_работе_тс_вывод();
        }

        private void Статистика_по_топливу_Click(object sender, RoutedEventArgs e)
        {
            Статистика_по_топливу_вывод();
        }

        private void Сформированить_отчет_Click(object sender, RoutedEventArgs e)
        {
            Формирование_отчета_на_основе_таблицы();
        }

        void Отчет_о_работе_тс_вывод()
        { 
        }
        void Статистика_по_топливу_вывод()
        {
        }
        void Формирование_отчета_на_основе_таблицы()
        {
        }

    }
}
