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
using System.Data.Entity;
using System.Data.Linq;
using System.Collections.ObjectModel;

namespace lb7.страницы
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        List<Водители> Lvod = new List<Водители>();
        
        public Page3()
        {
            InitializeComponent();

            DataGridUpdateDate();
        }

        private void DataGridUpdateDate()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {

              //      dGrid.ItemsSource = _context.ВодителиSet.ToList();
                    Lvod= _context.ВодителиSet.ToList();
                    dGrid.ItemsSource = Lvod.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выгрузки таблицы" + ex.Message); }
        }

        private void нанять_водителя_Click(object sender, RoutedEventArgs e)
        {
            добавить_водителя();
        }

        private void изменить_Click(object sender, RoutedEventArgs e)
        {

        }

        private void уволить_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Отобразить_Click(object sender, RoutedEventArgs e)
        {

        }
        
        void отобразить_список_водителей()
        {

        }
        void отобразить_конкретного_водителя_TABNOMER()
        {
            if (TbTabNumber.Text != "")
            {
                dGrid.ItemsSource = from d in Lvod
                                    where d.Табельный_номер == int.Parse(TbTabNumber.Text)
                                    select d;
            }
            else
            {
                dGrid.ItemsSource = from d in Lvod 
                                    select d;
            }
        }
        void отобразить_конкретного_водителя_FNAME()
        {
            if (tbName.Text != "")
            {
                dGrid.ItemsSource = from d in Lvod
                                    where d.ФИО.ToLower().Contains(tbName.Text.ToLower())
                                    select d;
            }
            else
            {
                dGrid.ItemsSource = from d in Lvod
                                    select d;
            }
        }

        void добавить_водителя()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    var vod = new Водители() { Табельный_номер = Convert.ToInt32(TbTabNumber.Text), ФИО = tbName.Text, Дата_взятия_на_работу = Convert.ToDateTime(tbDataEmployment.Text) };
                    _context.ВодителиSet.Add(vod);
                    _context.SaveChanges();
                    DataGridUpdateDate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так" + ex);
            }
        }
        void изменить_водителя()
        {
    //        this._context.SaveChanges();
        }
        void удалить_водителя()
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void TbTabNumber_KeyUp(object sender, KeyEventArgs e)
        {
            отобразить_конкретного_водителя_TABNOMER();
        }

        private void tbName_KeyUp(object sender, KeyEventArgs e)
        {
            отобразить_конкретного_водителя_FNAME();
        }
    }
}
