﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BasicSchoolWepApp.Models.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BasicSchoolDbEntities : DbContext
    {
        public BasicSchoolDbEntities()
            : base("name=BasicSchoolDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Dersler> tbl_Dersler { get; set; }
        public virtual DbSet<tbl_Kulupler> tbl_Kulupler { get; set; }
        public virtual DbSet<tbl_Notlar> tbl_Notlar { get; set; }
        public virtual DbSet<tbl_Ogrenciler> tbl_Ogrenciler { get; set; }
    }
}
