using DataBase;
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
    public partial class Page4 : Page, IActionsBdForms
    {
        List<Автомобили> Lavt = new List<Автомобили>();
        public Page4()
        {
            InitializeComponent();

        }

        public void DataGridUpdateDate()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    Lavt = _context.АвтомобилиSet.ToList();
                    dGrid.ItemsSource = Lavt.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выгрузки таблицы" + ex.Message); }
        }

        public void ADD()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    var avt = new Автомобили() { Регистрационный_номер = TbAutoNumber.Text, Марка_авто = tbMark.Text, Дата_выпуска = (DateTime)dataPick.SelectedDate, ВодителиТабельный_номер=int.Parse(comboBox.Text) };
                    _context.АвтомобилиSet.Add(avt);
                    _context.SaveChanges();
                    DataGridUpdateDate();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Что-то пошло не так: " + ex.Message);
            }
        }

        public void UPD()
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    var result = _context.АвтомобилиSet.SingleOrDefault(b => b.Регистрационный_номер == TbAutoNumber.Text);
                    if (result != null)
                    {
                        result.Марка_авто = tbMark.Text;
                        result.Дата_выпуска = (DateTime)dataPick.SelectedDate;
                        result.ВодителиТабельный_номер = int.Parse(comboBox.Text);
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
                    var result = _context.АвтомобилиSet.SingleOrDefault(b => b.Регистрационный_номер == TbAutoNumber.Text);
                    if (result != null)
                    {
                        _context.АвтомобилиSet.Remove(result);
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

        private void отобразить_машины_Click(object sender, RoutedEventArgs e)
        {

        }

        private void добавить_авто_Click(object sender, RoutedEventArgs e)
        {

        }

        private void изменить_авто_Click(object sender, RoutedEventArgs e)
        {

        }

        private void удалить_авто_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TbAutoNumber_KeyUp(object sender, KeyEventArgs e)
        {

        }
        private void TbAutoNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

        }
        private void tbMark_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void comboBox_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    List<Водители> vod = _context.ВодителиSet.ToList();
                    comboBox.ItemsSource = from v in vod
                                           select v.Табельный_номер;
                   
                    //  dGrid.ItemsSource = Lvod.ToList();
                }
            }
            catch (Exception ex) { MessageBox.Show("Ошибка выгрузки таблицы" + ex.Message); }
        }
    }
}
