//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrintingHousesApp
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CerberusDBEntities : DbContext
    {
        public CerberusDBEntities()
            : base("name=CerberusDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DeliveriesPostOffices> DeliveriesPostOffices { get; set; }
        public virtual DbSet<Newspapers> Newspapers { get; set; }
        public virtual DbSet<PostOffices> PostOffices { get; set; }
        public virtual DbSet<PrintingHouses> PrintingHouses { get; set; }
        public virtual DbSet<PrintingNewspapers> PrintingNewspapers { get; set; }
    }
}
