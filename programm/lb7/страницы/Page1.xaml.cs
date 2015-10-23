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

        }

        private void del_Click(object sender, RoutedEventArgs e)
        {

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
                    var put = new Путевые_листы() { Номер_путевого=int.Parse(tb1NumberPutevogo.Text), ВодителиТабельный_номер=int.Parse(tb1NumberTabelnogo.Text),
                    АвтомобилиРегистрационный_номер=tb1NumberAvto.Text,Показания_спидометра=int.Parse(tb2PokazSpidometra.Text), Остаток_топлива=int.Parse(tb2OstTopliva.Text),
                    Дата_и_время_отправления=Convert.ToDateTime(tb2DateTime.Text)};
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
            throw new NotImplementedException();
        }

        public void DEL()
        {
            throw new NotImplementedException();
        }

        private void Clear_update_Click(object sender, RoutedEventArgs e)
        {
            DataGridUpdateDate();
            tb2DateTime.SelectedDate = DateTime.Today;
            tb3DateTime.SelectedDate = DateTime.Today;
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

    }
}
