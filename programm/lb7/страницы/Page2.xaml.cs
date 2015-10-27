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
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using DataBase;

namespace lb7.страницы
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page2 : System.Windows.Controls.Page
    {
        
        public Page2()
        {
            InitializeComponent();
            DatePick.SelectedDate = DateTime.Today;
        }
        void initDataGrid()
        {
         //   dgrid.ItemsSource=
        }
        private void initWORD()
        {
            List<HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1_Result> Lputotch = new List<HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1_Result>();
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
       
                    DateTime? par = Convert.ToDateTime(DatePick.SelectedDate);

                    foreach (var v in _context.HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1(par))
                    {
                        Lputotch.Add(v);
                    }
                    
                }
            }
            catch (Exception ex)
            { MessageBox.Show(Convert.ToString(ex)); return; }


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
            wordrange.Font.Size = 16;
            wordrange.Font.Name = "Times New Roman";
            

            Microsoft.Office.Interop.Word.Table wordtable = doc.Tables.Add(wordrange, 2+ Lputotch.Count, 7, ref defaultTableBehavior, ref autoFitBehavior);

            wordtable.Rows.Alignment = Microsoft.Office.Interop.Word.WdRowAlignment.wdAlignRowCenter;

            Microsoft.Office.Interop.Word.Range wordcellrange = doc.Tables[1].Cell(1, 2).Range;

            wordcellrange = wordtable.Cell(1, 1).Range;
            wordcellrange.Text = "Отчет о работе транспортных средств за "+DatePick.SelectedDate.Value.ToString("MMMM")+" "+ DatePick.SelectedDate.Value.Year+"-го года";
            wordcellrange = wordtable.Cell(2, 1).Range;
            wordcellrange.Text = "№ п/п";
            wordcellrange = wordtable.Cell(2, 2).Range;
            wordcellrange.Text = "Наименование транспорта";
            wordcellrange = wordtable.Cell(2, 3).Range;
            wordcellrange.Text = "Выполняемая работа";
            wordcellrange = wordtable.Cell(2, 4).Range;
            wordcellrange.Text = "Остаток на начало месяца";
            wordcellrange = wordtable.Cell(2, 5).Range;
            wordcellrange.Text = "Получено за месяц";
            wordcellrange = wordtable.Cell(2, 6).Range;
            wordcellrange.Text = "Расход";
            wordcellrange = wordtable.Cell(2, 7).Range;
            wordcellrange.Text = "Остаток на конец месяца";

            int i = 2;
            foreach(var sv in Lputotch)
            {
                i++;
                wordcellrange = wordtable.Cell(i, 1).Range;
                wordcellrange.Text = i-2+"";
                wordcellrange = wordtable.Cell(i, 2).Range;
                wordcellrange.Text = sv.Марка_авто+"\n ("+sv.Регистрационный_номер+")";
                wordcellrange = wordtable.Cell(i, 3).Range;
                wordcellrange.Text = "Перевозка людей, оборудования, материалов";
                wordcellrange = wordtable.Cell(i, 4).Range;
                wordcellrange.Text = sv.Остаток_Топлива_При_Выезде_На_Первое_число+"";
                wordcellrange = wordtable.Cell(i, 5).Range;
                wordcellrange.Text = sv.Количество_литров_за_месяц+"";
                wordcellrange = wordtable.Cell(i, 6).Range;
                wordcellrange.Text =sv.Расход_за_месяц+"";
                wordcellrange = wordtable.Cell(i, 7).Range;
                wordcellrange.Text =sv.Остаток_Топлива_При_Возвращении_На_Последнее_число+ "";
            }

            object begCell = wordtable.Cell(1, 1).Range.Start;
            object endCell = wordtable.Cell(1, 7).Range.End;


           
            wordcellrange = doc.Range(ref begCell, ref endCell);
            wordcellrange.Select();
            wordcellrange.Cells.Shading.BackgroundPatternColor = WdColor.wdColorGray10;
            wordcellrange.Font.Size = 26;
            
            word.Selection.Cells.Merge();
            

            
        }

        void iitializeExcel()
        {

            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


           
            xlApp.Application.Workbooks.Add(Type.Missing);
            xlApp.Columns.ColumnWidth = 30;
            xlApp.Cells[1, 1] = "ОТЧЕТ: Работа тс";
            xlApp.Cells[1, 2] = "Создан: " + Convert.ToString(DateTime.Now);
            xlApp.Cells[3, 1] = "Регистрационный знак авто";
            xlApp.Cells[3, 2] = "Марка автомобиля";
            xlApp.Cells[3, 3] = "Время автомобиля в наряде в часах";

            xlApp.Visible = true;
        }
        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
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
            initWORD();
        }
        void Статистика_по_топливу_вывод()
        {
        }
        void Формирование_отчета_на_основе_таблицы()
        {
        }

        private void buttontest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
