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
using DataBase;
namespace lb7.страницы
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
     /*       using (Model2Container bd = new Model2Container())
            {
                dataGrid.Items.Add(bd.Путевые_листыSet.ToList());
            }*/
        }

        string NumberPutevogo1, NumberTabelnogo1, NumberAvto1;
        private void bbs_Click(object sender, RoutedEventArgs e)
        {
            
        }
        void добавить_путевой_лист()
        {
            if(tb1NumberAvto.Text!="" && tb1NumberPutevogo.Text!="" && tb1NumberTabelnogo.Text!="")
            {
                NumberPutevogo1 = tb1NumberAvto.Text;
                NumberTabelnogo1 = tb1NumberPutevogo.Text;
                NumberAvto1 = tb1NumberTabelnogo.Text;
            }
        }
        void изменить_путевой_лист()
        {

        }
        void удалить_путевой_лист()
        {

        }
        private void add_Click(object sender, RoutedEventArgs e)
        {
            добавить_путевой_лист();
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
        {
          
        }

        private void upd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
