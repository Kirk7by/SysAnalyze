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
            изменить_водителя();
        }
        private void уволить_Click(object sender, RoutedEventArgs e)
        {
            удалить_водителя();
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
            if (TbTabNumber.Text == "")
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
                MessageBox.Show("Что-то пошло не так" + ex.Message);
            }
        }
        void изменить_водителя()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    int tabnumber = int.Parse(TbTabNumber.Text);
                    var result = _context.ВодителиSet.SingleOrDefault(b => b.Табельный_номер == tabnumber);
                    if (result != null)
                    {
                        result.ФИО = tbName.Text;
                        result.Дата_взятия_на_работу = Convert.ToDateTime(tbDataEmployment.Text);
                        _context.SaveChanges();
                    }
                    DataGridUpdateDate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + ex.Message);
            }

        }
        void удалить_водителя()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    int tabnumber = int.Parse(TbTabNumber.Text);
                    var result = _context.ВодителиSet.SingleOrDefault(b => b.Табельный_номер == tabnumber);
                    if (result != null)
                    {
                        _context.ВодителиSet.Remove(result);
                        _context.SaveChanges();
                    }
                    DataGridUpdateDate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + ex.Message);
            }
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

        private void dGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (dGrid.SelectedItem != null)
            {
                Водители vod = dGrid.SelectedItem as Водители;
                TbTabNumber.Text = Convert.ToString(vod.Табельный_номер);
                tbName.Text = vod.ФИО;
                tbDataEmployment.Text = Convert.ToString(vod.Дата_взятия_на_работу);
            }
        }

        private void TbTabNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true;
            }
        }

        private void Обновить_и_почистить_Click(object sender, RoutedEventArgs e)
        {
            tbDataEmployment.Text = "";
            tbName.Text = "";
            TbTabNumber.Text = "";
            tbDataEmployment_KeyUp(sender, null);
            DataGridUpdateDate();
        }

        private void checkBoxToday_Checked(object sender, RoutedEventArgs e)
        {
            tbDataEmployment.Text = Convert.ToString(DateTime.Today.Date);
        }
        private void tbDataEmployment_KeyUp(object sender, KeyEventArgs e)
        {
            checkBoxToday.IsChecked = false;
        }
    }
}
