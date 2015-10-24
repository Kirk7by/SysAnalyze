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
using System.Threading;

namespace lb7.страницы
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page, IActionsBdForms
    {
        List<Путевые_листы> Lput = new List<Путевые_листы>();
        public Page1()
        {
            InitializeComponent();
            Clear_update_Click(null, null);
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            ADD();
        }
        private void upd_Click(object sender, RoutedEventArgs e)
        {
            UPD();
        }
        private void del_Click(object sender, RoutedEventArgs e)
        {
            DEL();
        }

        public void DataGridUpdateDate()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    Lput = _context.Путевые_листыSet.ToList();
                    dGrid.ItemsSource = Lput.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выгрузки таблицы: " + ex.Message); }
        }
        public void ADD()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    Путевые_листы put = new Путевые_листы()
                    {
                        Номер_путевого = int.Parse(tb1NumberPutevogo.Text),
                        ВодителиТабельный_номер = int.Parse(tb1NumberTabelnogo.Text),
                        АвтомобилиРегистрационный_номер = tb1NumberAvto.Text,
                        Показания_спидометра = int.Parse(tb2PokazSpidometra.Text),
                        Остаток_топлива = int.Parse(tb2OstTopliva.Text),
                        Дата_и_время_отправления = Convert.ToDateTime(tb2DateTime.Text)
                    };
                    if (tb3OstTopliva.Text != ""&& tb3PokazSpidometra.Text!="")
                    {
                        put.Показания_спидометра_при_приезде = int.Parse(tb3PokazSpidometra.Text);
                        put.Остаток_топлива_при_приезде = int.Parse(tb3OstTopliva.Text);
                        put.Дата_время_возвращения = Convert.ToDateTime(tb3DateTime.Text);
                        if(ch4Infozapr.IsChecked==true)
                        {
                            put.Количество_литров = int.Parse(tb4KolvoLitrov.Text);
                            put.Марка_топлива = tb4MarkaTopliva.Text;
                        }
                    }
                    _context.Путевые_листыSet.Add(put);
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
                    int tabnumber = int.Parse(tb1NumberPutevogo.Text);
                    var result = _context.Путевые_листыSet.SingleOrDefault(b => b.Номер_путевого == tabnumber);
                    if (result != null)
                    {
                        result.ВодителиТабельный_номер = int.Parse(tb1NumberTabelnogo.Text);
                        result.АвтомобилиРегистрационный_номер = tb1NumberAvto.Text;

                        result.Дата_и_время_отправления = Convert.ToDateTime(tb2DateTime.SelectedDate);
                        result.Показания_спидометра = int.Parse(tb2PokazSpidometra.Text);
                        result.Остаток_топлива = int.Parse(tb2OstTopliva.Text);

                        result.Показания_спидометра_при_приезде = int.Parse(tb3PokazSpidometra.Text);
                        result.Дата_время_возвращения = Convert.ToDateTime(tb3DateTime.SelectedDate);
                        result.Остаток_топлива_при_приезде = int.Parse(tb3OstTopliva.Text);

                        if(ch4Infozapr.IsChecked==true)
                        {
                            result.Марка_топлива = tb4MarkaTopliva.Text;
                            result.Количество_литров = int.Parse(tb4KolvoLitrov.Text);
                        }

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
                    int tabnumber = int.Parse(tb1NumberPutevogo.Text);
                    var result = _context.Путевые_листыSet.SingleOrDefault(b => b.Номер_путевого == tabnumber);
                    if (result != null)
                    {
                        _context.Путевые_листыSet.Remove(result);
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

        private void Clear_update_Click(object sender, RoutedEventArgs e)
        {
            DataGridUpdateDate();
            tb2DateTime.SelectedDate = DateTime.Today;
            tb3DateTime.SelectedDate = DateTime.Today;
            tb1NumberTabelnogo.Text = "";
            tb1NumberPutevogo.Text = "";
            tb1NumberAvto.Text = "";
            tb2OstTopliva.Text = "";
            tb2PokazSpidometra.Text = "";
            tb3OstTopliva.Text = "";
            tb3PokazSpidometra.Text = "";
            tb4KolvoLitrov.Text = "";
            tb4MarkaTopliva.Text = "";
        }

        private void tb1NumberTabelnogotb1NumberAvto_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    List<Водители> vod = _context.ВодителиSet.ToList();
                    tb1NumberTabelnogo.ItemsSource = from v in vod
                                           select v.Табельный_номер;
                    List<Автомобили> avt = _context.АвтомобилиSet.ToList();
                    tb1NumberAvto.ItemsSource = from v in avt
                                                select v.Регистрационный_номер;
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выгрузки таблицы: " + ex.Message); }
        }

        private void dGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dGrid.SelectedItem != null)
            {
                Путевые_листы puts = dGrid.SelectedItem as Путевые_листы;
                tb1NumberPutevogo.Text = Convert.ToString(puts.Номер_путевого);
                tb1NumberAvto.Text= puts.АвтомобилиРегистрационный_номер;
                tb1NumberTabelnogo.Text= Convert.ToString(puts.ВодителиТабельный_номер);

                tb2DateTime.SelectedDate = puts.Дата_и_время_отправления;
                tb2PokazSpidometra.Text= Convert.ToString(puts.Показания_спидометра);
                tb2OstTopliva.Text= Convert.ToString(puts.Остаток_топлива);

                tb3DateTime.SelectedDate = puts.Дата_время_возвращения;
                tb3PokazSpidometra.Text= Convert.ToString(puts.Показания_спидометра_при_приезде);
                tb3OstTopliva.Text= Convert.ToString(puts.Остаток_топлива_при_приезде);

                tb4KolvoLitrov.Text= Convert.ToString(puts.Количество_литров);
                tb4MarkaTopliva.Text =puts.Марка_топлива;
            }
        }
    }
}
