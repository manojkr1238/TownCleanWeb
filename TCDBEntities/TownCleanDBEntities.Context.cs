﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TCDBEntities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TownClean_DBEntities : DbContext
    {
        public TownClean_DBEntities()
            : base("name=TownClean_DBEntities")
        {

        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Quotation_Details> Quotation_Details { get; set; }
        public virtual DbSet<Quotation_Item_Details> Quotation_Item_Details { get; set; }
        public virtual DbSet<QuotationServiceMaster> QuotationServiceMasters { get; set; }
        public virtual DbSet<BranchMaster> BranchMasters { get; set; }
    }
}
