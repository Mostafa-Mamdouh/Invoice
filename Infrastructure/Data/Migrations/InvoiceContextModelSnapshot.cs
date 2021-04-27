﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(InvoiceContext))]
    partial class InvoiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.InvoiceHDR", b =>
                {
                    b.Property<int>("InvoiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Customer")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("PaymentMethod")
                        .HasColumnType("bit");

                    b.HasKey("InvoiceId");

                    b.ToTable("InvoiceHDR");
                });

            modelBuilder.Entity("Core.Entities.ItemsDTL", b =>
                {
                    b.Property<int>("ItemCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("InvoiceId")
                        .HasColumnType("int");

                    b.Property<string>("ItemName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(14,3)");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.HasKey("ItemCode");

                    b.HasIndex("InvoiceId");

                    b.ToTable("ItemsDTL");
                });

            modelBuilder.Entity("Core.Entities.ItemsDTL", b =>
                {
                    b.HasOne("Core.Entities.InvoiceHDR", "InvoiceHDR")
                        .WithMany("ItemsDTLs")
                        .HasForeignKey("InvoiceId")
                        .HasConstraintName("FK_ItemsDTL_InvoiceHDR")
                        .IsRequired();

                    b.Navigation("InvoiceHDR");
                });

            modelBuilder.Entity("Core.Entities.InvoiceHDR", b =>
                {
                    b.Navigation("ItemsDTLs");
                });
#pragma warning restore 612, 618
        }
    }
}