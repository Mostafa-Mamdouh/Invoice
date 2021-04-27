using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class ItemsDTLConfiguration : IEntityTypeConfiguration<ItemsDTL>
    {
        public void Configure(EntityTypeBuilder<ItemsDTL> builder)
        {
            builder.ToTable("ItemsDTL").HasKey(x => x.ItemCode);
            builder.Property(e => e.ItemCode).ValueGeneratedOnAdd();
            builder.Property(e => e.InvoiceId);
            builder.Property(e => e.ItemName).HasMaxLength(150);
            builder.Property(e => e.QTY);
            builder.Property(e => e.Price).HasColumnType("decimal(14, 3)");

            builder.HasOne(d => d.InvoiceHDR)
            .WithMany(p => p.ItemsDTLs)
            .HasForeignKey(d => d.InvoiceId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ItemsDTL_InvoiceHDR");

        }
    }
}
