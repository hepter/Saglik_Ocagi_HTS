﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sağlık_Ocağı_HTS
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class saglikDBEntities1 : DbContext
    {
        public saglikDBEntities1()
            : base("name=saglikDBEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cikis> cikis { get; set; }
        public virtual DbSet<hasta> hasta { get; set; }
        public virtual DbSet<islem> islem { get; set; }
        public virtual DbSet<kullanici> kullanici { get; set; }
        public virtual DbSet<poliklinik> poliklinik { get; set; }
        public virtual DbSet<sevk> sevk { get; set; }
    
        public virtual int userCheck(string username, ObjectParameter result)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("userCheck", usernameParameter, result);
        }
    }
}
