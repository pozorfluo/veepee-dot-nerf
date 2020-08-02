﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VeepeeDotNerf.Data;

namespace VeepeeDotNerf.Migrations
{
    [DbContext(typeof(VeepeeDotNerfContext))]
    [Migration("20200802035301_RenameTables")]
    partial class RenameTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VeepeeDotNerf.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("address_id")
                        .HasColumnType("int");

                    b.Property<string>("city")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("clientForeignKey")
                        .HasColumnName("client_id")
                        .HasColumnType("int");

                    b.Property<int>("countryForeignKey")
                        .HasColumnName("country_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("line1")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("line2")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("zipCode")
                        .IsRequired()
                        .HasColumnName("zip_code")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("clientForeignKey");

                    b.HasIndex("countryForeignKey");

                    b.ToTable("address");
                });

            modelBuilder.Entity("VeepeeDotNerf.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("client_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("client");
                });

            modelBuilder.Entity("VeepeeDotNerf.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("country_id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("country");
                });

            modelBuilder.Entity("VeepeeDotNerf.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("order_id")
                        .HasColumnType("int");

                    b.Property<int>("ApiOrderId")
                        .HasColumnName("api_order_id")
                        .HasColumnType("int");

                    b.Property<int>("clientForeignKey")
                        .HasColumnName("client_id")
                        .HasColumnType("int");

                    b.Property<string>("paymentMethod")
                        .IsRequired()
                        .HasColumnName("payment_method")
                        .HasColumnType("varchar(32)");

                    b.Property<int>("productForeignKey")
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnName("status")
                        .HasColumnType("varchar(32)");

                    b.Property<decimal>("total")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("clientForeignKey");

                    b.HasIndex("productForeignKey");

                    b.ToTable("order_info");
                });

            modelBuilder.Entity("VeepeeDotNerf.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("product_id")
                        .HasColumnType("int");

                    b.Property<DateTime>("createdAt")
                        .HasColumnName("created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("varchar(500) CHARACTER SET utf8mb4")
                        .HasMaxLength(500);

                    b.Property<bool>("hot")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("inventory")
                        .HasColumnType("int");

                    b.Property<decimal>("msrp")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("sku")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("updatedAt")
                        .HasColumnName("updated_at")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("VeepeeDotNerf.Models.Address", b =>
                {
                    b.HasOne("VeepeeDotNerf.Models.Client", "client")
                        .WithMany("Addresses")
                        .HasForeignKey("clientForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VeepeeDotNerf.Models.Country", "country")
                        .WithMany("Addresses")
                        .HasForeignKey("countryForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VeepeeDotNerf.Models.Order", b =>
                {
                    b.HasOne("VeepeeDotNerf.Models.Client", "client")
                        .WithMany()
                        .HasForeignKey("clientForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VeepeeDotNerf.Models.Product", "product")
                        .WithMany()
                        .HasForeignKey("productForeignKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}