using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class Repository
    {
        public void ADD(int TbTabNumber, string FIO, DateTime data)
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    var vod = new Водители() { Табельный_номер = TbTabNumber, ФИО = FIO, Дата_взятия_на_работу = data };
                    _context.ВодителиSet.Add(vod);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                
            }
        }
        public void ADD(string RegNumber, string AutoMark, DateTime data, int TbTabNumber)
        {
            try
            {
                using (BdModelContainer _context = new BdModelContainer())
                {
                    var aut = new Автомобили() { Регистрационный_номер = RegNumber, Марка_авто = AutoMark, Дата_выпуска = data, ВодителиТабельный_номер =TbTabNumber };
                    _context.АвтомобилиSet.Add(aut);
                    _context.SaveChanges();
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
