﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TableReadyADO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TableReadyTotalEntities : DbContext
    {
        public TableReadyTotalEntities()
            : base("name=TableReadyTotalEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Layout> Layouts { get; set; }
        public virtual DbSet<ReservationEntry> ReservationEntries { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<TableAvailabilityDate> TableAvailabilityDates { get; set; }
        public virtual DbSet<TableGroup> TableGroups { get; set; }
        public virtual DbSet<TableInGroup> TableInGroups { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<WaitlistEntry> WaitlistEntries { get; set; }
    }
}
