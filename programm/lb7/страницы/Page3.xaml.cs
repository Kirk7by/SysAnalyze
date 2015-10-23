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
    public partial class Page3 : Page, IActionsBdForms
    {
        List<Водители> Lvod = new List<Водители>();
        
        public Page3()
        {
            InitializeComponent();
            Обновить_и_почистить_Click(null, null);
        }

        public void DataGridUpdateDate()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    Lvod= _context.ВодителиSet.ToList();
                    dGrid.ItemsSource = Lvod.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выгрузки таблицы" + ex.Message); }
        }

        private void нанять_водителя_Click(object sender, RoutedEventArgs e)
        {
            ADD();
        }
        private void изменить_Click(object sender, RoutedEventArgs e)
        {
            UPD();
        }
        private void уволить_Click(object sender, RoutedEventArgs e)
        {
            DEL();
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

        public void ADD()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    var vod = new Водители() { Табельный_номер = Convert.ToInt32(TbTabNumber.Text), ФИО = tbName.Text, Дата_взятия_на_работу = (DateTime)dataPick.SelectedDate };
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
        public void UPD()
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
                        result.Дата_взятия_на_работу = (DateTime)dataPick.SelectedDate;
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
        public void DEL()
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
                dataPick.SelectedDate= vod.Дата_взятия_на_работу;
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
            
            tbName.Text = "";
            TbTabNumber.Text = "";
            dataPick.SelectedDate = DateTime.Today;
            DataGridUpdateDate();
        }
    }
}
