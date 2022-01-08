﻿// <auto-generated />
using System;
using ERP_Web_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ERP_Web_App.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220105164455_Update01")]
    partial class Update01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ERP_Web_App.Models.Brand", b =>
                {
                    b.Property<int>("BrandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("BrandId");

                    b.ToTable("BrandMaster");
                });

            modelBuilder.Entity("ERP_Web_App.Models.Model", b =>
                {
                    b.Property<long>("ModelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("ModelId");

                    b.HasIndex("BrandId");

                    b.ToTable("ModelMaster");
                });

            modelBuilder.Entity("ERP_Web_App.Models.Source", b =>
                {
                    b.Property<long>("SourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("IMEI")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IMEI2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LotNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ModelId")
                        .HasColumnType("int");

                    b.Property<long?>("ModelId1")
                        .HasColumnType("bigint");

                    b.Property<string>("RAM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ROM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("SourceId");

                    b.HasIndex("BrandId");

                    b.HasIndex("ModelId1");

                    b.ToTable("SourceMaster");
                });

            modelBuilder.Entity("ERP_Web_App.Models.Model", b =>
                {
                    b.HasOne("ERP_Web_App.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ERP_Web_App.Models.Source", b =>
                {
                    b.HasOne("ERP_Web_App.Models.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERP_Web_App.Models.Model", "Model")
                        .WithMany()
                        .HasForeignKey("ModelId1");

                    b.Navigation("Brand");

                    b.Navigation("Model");
                });
#pragma warning restore 612, 618
        }
    }
}
