//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lb7
{
    using System;
    using System.Collections.Generic;
    
    public partial class Путевые_листы
    {
        public int Номер_путевого { get; set; }
        public System.DateTime Дата_и_время_отправления { get; set; }
        public Nullable<int> Показания_спидометра { get; set; }
        public Nullable<int> Остаток_топлива { get; set; }
        public Nullable<int> Остаток_топлива_при_приезде { get; set; }
        public Nullable<int> Показания_спидометра_при_приезде { get; set; }
        public string Марка_топлива { get; set; }
        public Nullable<System.DateTime> Дата_время_возвращения { get; set; }
        public Nullable<int> Количество_литров { get; set; }
    
        public virtual Водители Водители { get; set; }
        public virtual Автомобили Автомобили { get; set; }
    }
}
