﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using Configurations;
    
    public partial class BdModelContainer : DbContext
    {
        public BdModelContainer()
            : base(@"metadata = res://*/BdModel.csdl|res://*/BdModel.ssdl|res://*/BdModel.msl;provider=System.Data.SqlClient;provider connection string=" + '\u0022' + @";data source="+config.Default.connectionsString+";integrated security=True;MultipleActiveResultSets=True;App=EntityFramework" + '\u0022' + ";")
        {
        }
        //connectionString="metadata=res://*/BdModel.csdl|res://*/BdModel.ssdl|res://*/BdModel.msl;provider=System.Data.SqlClient;provider connection string=&quot;data source=(LocalDb)\MSSQLLocalDB;initial catalog=SysAnalyze;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" providerName="System.Data.EntityClient" />
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Водители> ВодителиSet { get; set; }
        public virtual DbSet<Автомобили> АвтомобилиSet { get; set; }
        public virtual DbSet<Путевые_листы> Путевые_листыSet { get; set; }
        public virtual DbSet<Путевые_листы_отчет> Путевые_листы_отчет { get; set; }
    
        public virtual ObjectResult<HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО_Result> HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО(Nullable<System.DateTime> dateMonth)
        {
            var dateMonthParameter = dateMonth.HasValue ?
                new ObjectParameter("dateMonth", dateMonth) :
                new ObjectParameter("dateMonth", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО_Result>("HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО", dateMonthParameter);
        }
    
        public virtual ObjectResult<HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1_Result> HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1(Nullable<System.DateTime> dateMonth)
        {
            var dateMonthParameter = dateMonth.HasValue ?
                new ObjectParameter("dateMonth", dateMonth) :
                new ObjectParameter("dateMonth", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1_Result>("HR_ОТЧЕТЫ_АКТ_ОБ_ОСТАТКАХ_ТОПЛИВА_ПО_КАЖДОМУ_АВТО1", dateMonthParameter);
        }
    }
}
