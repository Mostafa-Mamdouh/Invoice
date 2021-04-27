using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Infrastructure.Data
{
    public class InvoiceContext : DbContext
    {
        public InvoiceContext( DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<InvoiceHDR> InvoiceHDRs { get; set; }
        public virtual DbSet<ItemsDTL> ItemsDTLs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
