﻿// <auto-generated />
using System;
using BreakDown_Assistance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BreakDown_Assistance.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BreakDown_Assistance.Models.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AdminID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AdminID");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("CategoryID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryTitle")
                        .IsRequired()
                        .HasColumnName("CategoryTitle")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryID");

                    b.HasAlternateKey("CategoryTitle");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ProductID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnName("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductTitle")
                        .IsRequired()
                        .HasColumnName("ProductTitle")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProductID");

                    b.HasAlternateKey("ProductTitle");

                    b.HasIndex("CategoryID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.Purchase", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PurchaseID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime");

                    b.Property<string>("PurchaseTitle")
                        .IsRequired()
                        .HasColumnName("PurchaseTitle")
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TotalPrice")
                        .HasColumnName("TotalPrice")
                        .HasColumnType("int");

                    b.HasKey("PurchaseID");

                    b.HasAlternateKey("PurchaseTitle");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.PurchaseDetail", b =>
                {
                    b.Property<int>("PurchaseDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PurchaseDetailID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("Price")
                        .HasColumnName("Price")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseID")
                        .HasColumnName("PurchaseID")
                        .HasColumnType("int");

                    b.Property<int>("PurchaseProductID")
                        .HasColumnName("PurchaseProductID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnName("Quantity")
                        .HasColumnType("int");

                    b.HasKey("PurchaseDetailID");

                    b.HasIndex("PurchaseID");

                    b.HasIndex("PurchaseProductID");

                    b.ToTable("PurchaseDetails");
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.PurchaseProduct", b =>
                {
                    b.Property<int>("PurchaseProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("PurchaseProductID")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID")
                        .HasColumnName("ProductID")
                        .HasColumnType("int");

                    b.HasKey("PurchaseProductID");

                    b.HasIndex("ProductID");

                    b.ToTable("PurchaseProduct");
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.Product", b =>
                {
                    b.HasOne("BreakDown_Assistance.Models.Category", "Category")
                        .WithMany("products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.PurchaseDetail", b =>
                {
                    b.HasOne("BreakDown_Assistance.Models.Purchase", "purchase")
                        .WithMany("purchaseDetails")
                        .HasForeignKey("PurchaseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BreakDown_Assistance.Models.PurchaseProduct", "purchaseProduct")
                        .WithMany("purchaseDetails")
                        .HasForeignKey("PurchaseProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BreakDown_Assistance.Models.PurchaseProduct", b =>
                {
                    b.HasOne("BreakDown_Assistance.Models.Product", "products")
                        .WithMany("purchaseProducts")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
