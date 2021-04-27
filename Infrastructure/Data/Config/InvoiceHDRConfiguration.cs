using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class InvoiceHDRConfiguration : IEntityTypeConfiguration<InvoiceHDR>
    {
        public void Configure(EntityTypeBuilder<InvoiceHDR> builder)
        {
            builder.ToTable("InvoiceHDR").HasKey(x=>x.InvoiceId);
            builder.Property(e => e.InvoiceId).ValueGeneratedOnAdd();
            builder.Property(e => e.InvoiceDate).HasColumnType("datetime");
            builder.Property(e => e.Description).HasMaxLength(500);
            builder.Property(e => e.Customer).HasMaxLength(150);
            builder.Property(e => e.PaymentMethod).HasColumnType("bit");
        }
    }
}
