﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace wb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class wbDBEntities1 : DbContext
    {
        public wbDBEntities1()
            : base("name=wbDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<active_threads> active_threads { get; set; }
        public virtual DbSet<comment> comments { get; set; }
        public virtual DbSet<error> errors { get; set; }
        public virtual DbSet<feedback> feedbacks { get; set; }
        public virtual DbSet<journal> journals { get; set; }
        public virtual DbSet<pm> pms { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<report> reports { get; set; }
        public virtual DbSet<thread> threads { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}