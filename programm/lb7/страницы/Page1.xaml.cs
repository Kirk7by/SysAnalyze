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
using Microsoft.Office.Interop.Word;

namespace lb7.страницы
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : System.Windows.Controls.Page, IActionsBdForms
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
                    if (tb3OstTopliva.Text != "" && tb3PokazSpidometra.Text != "")
                    {
                        put.Показания_спидометра_при_приезде = int.Parse(tb3PokazSpidometra.Text);
                        put.Остаток_топлива_при_приезде = int.Parse(tb3OstTopliva.Text);
                        put.Дата_время_возвращения = Convert.ToDateTime(tb3DateTime.Text);
                        if (ch4Infozapr.IsChecked == true)
                        {
                            put.Количество_литров = int.Parse(tb4KolvoLitrov.Text);
                            put.Марка_топлива = tb4MarkaTopliva.Text;
                            if (tb4KolvoLitrov.Text != "")
                                put.Расход = int.Parse(tb2OstTopliva.Text) - int.Parse(tb3OstTopliva.Text) + int.Parse(tb4KolvoLitrov.Text);
                            else
                                put.Расход = int.Parse(tb2OstTopliva.Text) - int.Parse(tb3OstTopliva.Text);
                        }
                        else
                        {
                            put.Расход = int.Parse(tb2OstTopliva.Text) - int.Parse(tb3OstTopliva.Text);
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


                        if (ch4Infozapr.IsChecked == true)
                        {
                            result.Марка_топлива = tb4MarkaTopliva.Text;
                            result.Количество_литров = int.Parse(tb4KolvoLitrov.Text);
                        }
                        if (tb4KolvoLitrov.Text != "")
                            result.Расход = int.Parse(tb2OstTopliva.Text) - int.Parse(tb3OstTopliva.Text) + int.Parse(tb4KolvoLitrov.Text);
                        else
                            result.Расход = int.Parse(tb2OstTopliva.Text) - int.Parse(tb3OstTopliva.Text);


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
                tb1NumberAvto.Text = puts.АвтомобилиРегистрационный_номер;
                tb1NumberTabelnogo.Text = Convert.ToString(puts.ВодителиТабельный_номер);

                tb2DateTime.SelectedDate = puts.Дата_и_время_отправления;
                tb2PokazSpidometra.Text = Convert.ToString(puts.Показания_спидометра);
                tb2OstTopliva.Text = Convert.ToString(puts.Остаток_топлива);

                tb3DateTime.SelectedDate = puts.Дата_время_возвращения;
                tb3PokazSpidometra.Text = Convert.ToString(puts.Показания_спидометра_при_приезде);
                tb3OstTopliva.Text = Convert.ToString(puts.Остаток_топлива_при_приезде);

                tb4KolvoLitrov.Text = Convert.ToString(puts.Количество_литров);
                tb4MarkaTopliva.Text = puts.Марка_топлива;
            }
        }

        private void WordButtons_Click(object sender, RoutedEventArgs e)
        {

        }

        private void WordButtons_Click_1(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Word.Application word = new Microsoft.Office.Interop.Word.Application(); //создаем COM-объект Word
            word.Visible = true;

            Microsoft.Office.Interop.Word.Document doc = word.Documents.Add();
            doc.Select();
            doc.PageSetup.TogglePortrait(); //горизонтальный вид

            Object defaultTableBehavior = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehavior = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitWindow;
            //Добавляем таблицу и получаем объект wordtable 





            Microsoft.Office.Interop.Word.Range wordrange = doc.Range(0, 1);
            wordrange.Select();
            wordrange.Font.Size = 14;
            wordrange.Font.Name = "Times New Roman";


            Microsoft.Office.Interop.Word.Table wordtable = doc.Tables.Add(wordrange, 15, 7, ref defaultTableBehavior, ref autoFitBehavior);
            wordtable.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;
            Microsoft.Office.Interop.Word.Range wordcellrange = doc.Tables[1].Cell(1, 2).Range;

            wordcellrange = wordtable.Cell(1, 1).Range;
            wordcellrange.Text = "Путевой лист №" + tb1NumberPutevogo.Text + " за " + tb2DateTime.Text;

            wordcellrange = wordtable.Cell(2, 1).Range;
            wordcellrange.Text = "Автомобиль, прицеп, полуприцеп";

            wordcellrange = wordtable.Cell(2, 4).Range;
            wordcellrange.Text = "Водитель";


            wordcellrange = wordtable.Cell(3, 1).Range;
            wordcellrange.Text = "Марка авто";
            wordcellrange = wordtable.Cell(3, 2).Range;
            wordcellrange.Text = "Регистрационный номер";
            wordcellrange = wordtable.Cell(3, 3).Range;
            wordcellrange.Text = "Гаражный номер";

            wordcellrange = wordtable.Cell(3, 4).Range;
            wordcellrange.Text = "ФИО";
            wordcellrange = wordtable.Cell(3, 5).Range;
            wordcellrange.Text = "Табельный номер";
            wordcellrange = wordtable.Cell(3, 6).Range;
            wordcellrange.Text = "По состоянию здоровья допущен, подпись";

            wordcellrange = wordtable.Cell(6, 1).Range;
            wordcellrange.Text = "Работа водителя и автомобиля";

            wordcellrange = wordtable.Cell(7, 1).Range;
            wordcellrange.Text = "Операция";
            wordcellrange = wordtable.Cell(7, 3).Range;
            wordcellrange.Text = "Показания спидометра";
            wordcellrange = wordtable.Cell(7, 5).Range;
            wordcellrange.Text = "Дата(число, месяц) время(час, мин)";

            wordcellrange = wordtable.Cell(8, 5).Range;
            wordcellrange.Text = "По графику";
            wordcellrange = wordtable.Cell(8, 6).Range;
            wordcellrange.Text = "Фактически";

            wordcellrange = wordtable.Cell(9, 1).Range;
            wordcellrange.Text = "Выезд на линию";
            wordcellrange = wordtable.Cell(10, 1).Range;
            wordcellrange.Text = "Возвращение с линии";


            wordcellrange = wordtable.Cell(12, 1).Range;
            wordcellrange.Text = "Движение топливно-смазочных материалов";

            wordcellrange = wordtable.Cell(13, 1).Range;
            wordcellrange.Text = "Заправка ТСМ";
            wordcellrange = wordtable.Cell(13, 4).Range;
            wordcellrange.Text = "Остаток ТСМ";

            wordcellrange = wordtable.Cell(14, 1).Range;
            wordcellrange.Text = "Дата";
            wordcellrange = wordtable.Cell(14, 2).Range;
            wordcellrange.Text = "Марка ТСМ";
            wordcellrange = wordtable.Cell(14, 3).Range;
            wordcellrange.Text = "Количество литров";
            wordcellrange = wordtable.Cell(14, 4).Range;
            wordcellrange.Text = "При выезде";
            wordcellrange = wordtable.Cell(14, 6).Range;
            wordcellrange.Text = "При возвращении";


            //заполнение
            #region TableMerge

            //объединение ячеек
            object begCell = wordtable.Cell(1, 1).Range.Start;
            object endCell = wordtable.Cell(1, 7).Range.End;

            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Cells.Shading.BackgroundPatternColor = WdColor.wdColorGray10;
            wordcellrange.Font.Size = 28;
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(2, 1).Range.Start;
            endCell = wordtable.Cell(2, 3).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Font.Size = 20;
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(2, 2).Range.Start;
            endCell = wordtable.Cell(2, 5).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Font.Size = 20;
            
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(3, 6).Range.Start;
            endCell = wordtable.Cell(3, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            //
            begCell = wordtable.Cell(4, 6).Range.Start;
            endCell = wordtable.Cell(4, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();



            begCell = wordtable.Cell(5, 1).Range.Start;
            endCell = wordtable.Cell(5, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Font.Size = 28;
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(6, 1).Range.Start;
            endCell = wordtable.Cell(6, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Font.Size = 20;
            word.Selection.Cells.Merge();



            begCell = wordtable.Cell(8, 6).Range.Start;
            endCell = wordtable.Cell(8, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(9, 6).Range.Start;
            endCell = wordtable.Cell(9, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(9, 3).Range.Start;
            endCell = wordtable.Cell(9, 4).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(7, 1).Range.Start;
            endCell = wordtable.Cell(8, 2).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(7, 2).Range.Start;
            endCell = wordtable.Cell(8, 3).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(7, 3).Range.Start;
            endCell = wordtable.Cell(7, 5).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();


            begCell = wordtable.Cell(11, 1).Range.Start;
            endCell = wordtable.Cell(11, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Font.Size = 28;
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(12, 1).Range.Start;
            endCell = wordtable.Cell(12, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Font.Size = 20;
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(13, 4).Range.Start;
            endCell = wordtable.Cell(13, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(13, 1).Range.Start;
            endCell = wordtable.Cell(13, 3).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(14, 6).Range.Start;
            endCell = wordtable.Cell(14, 7).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(14, 4).Range.Start;
            endCell = wordtable.Cell(14, 5).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();


            begCell = wordtable.Cell(9, 1).Range.Start;
            endCell = wordtable.Cell(9, 2).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(10, 3).Range.Start;
            endCell = wordtable.Cell(10, 4).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(10, 1).Range.Start;
            endCell = wordtable.Cell(10, 2).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(10, 4).Range.Start;
            endCell = wordtable.Cell(10, 5).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(15, 4).Range.Start;
            endCell = wordtable.Cell(15, 5).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();
            begCell = wordtable.Cell(15, 5).Range.Start;
            endCell = wordtable.Cell(15, 6).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            word.Selection.Cells.Merge();

            begCell = wordtable.Cell(1, 1).Range.Start;
            endCell = wordtable.Cell(15, 5).Range.End;
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Rows.Alignment = WdRowAlignment.wdAlignRowCenter;
            #endregion

            //Make Auto
            
            try {

                using (BdModelContainer _context = new BdModelContainer())
                {
                    //Vehicle
                    wordcellrange = wordtable.Cell(4, 1).Range;
                    wordcellrange.Text = _context.АвтомобилиSet.SingleOrDefault(item => item.Регистрационный_номер == tb1NumberAvto.Text).Марка_авто;
                    wordcellrange = wordtable.Cell(4, 2).Range;
                    wordcellrange.Text = tb1NumberAvto.Text;
                    wordcellrange = wordtable.Cell(4, 3).Range;
                    wordcellrange.Text = "-";

                    int tbnumber_ = Convert.ToInt32(tb1NumberTabelnogo.Text);
                    //Driver
                    wordcellrange = wordtable.Cell(4, 4).Range;
                    wordcellrange.Text = _context.ВодителиSet.SingleOrDefault((item) => item.Табельный_номер == tbnumber_).ФИО;
                    wordcellrange = wordtable.Cell(4, 5).Range;
                    wordcellrange.Text = tb1NumberTabelnogo.Text;
                    wordcellrange = wordtable.Cell(4, 6).Range;
                    wordcellrange.Text = "-";
                    //*/
                }

                //Drivers and Vehicle
                wordcellrange = wordtable.Cell(9, 2).Range;
                wordcellrange.Text = tb2PokazSpidometra.Text;
                wordcellrange = wordtable.Cell(10, 2).Range;
                wordcellrange.Text = tb3PokazSpidometra.Text;
                wordcellrange = wordtable.Cell(9, 3).Range;
                wordcellrange.Text = tb2DateTime.Text;
                wordcellrange = wordtable.Cell(9, 4).Range;
                wordcellrange.Text = tb2DateTime.Text;
                wordcellrange = wordtable.Cell(10, 3).Range;
                wordcellrange.Text = tb3DateTime.Text;
                wordcellrange = wordtable.Cell(10, 4).Range;
                wordcellrange.Text = tb3DateTime.Text;

                //Fuel
                wordcellrange = wordtable.Cell(15, 1).Range;
                wordcellrange.Text = tb3DateTime.Text;
                wordcellrange = wordtable.Cell(15, 2).Range;
                wordcellrange.Text = tb4MarkaTopliva.Text;
                wordcellrange = wordtable.Cell(15, 3).Range;
                wordcellrange.Text = tb4KolvoLitrov.Text;

                wordcellrange = wordtable.Cell(15, 4).Range;
                wordcellrange.Text = tb2OstTopliva.Text;
                wordcellrange = wordtable.Cell(15, 5).Range;
                wordcellrange.Text = tb3OstTopliva.Text;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникли проблемы с подстановкой данных в таблицу \n\n" + ex.Message);
            }

        }
    }
}
