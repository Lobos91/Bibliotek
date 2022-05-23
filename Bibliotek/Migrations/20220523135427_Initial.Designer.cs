﻿// <auto-generated />
using System;
using Bibliotek.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bibliotek.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220523135427_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Bibliotek.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Lent")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LoanDateTimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("LoanDateTimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(2);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("Type").HasValue("ProductModel");
                });

            modelBuilder.Entity("Bibliotek.Models.ReleaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Pages")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ReleaseModels");
                });

            modelBuilder.Entity("Bibliotek.Models.UserModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Bibliotek.Models.BookModel", b =>
                {
                    b.HasBaseType("Bibliotek.Models.ProductModel");

                    b.Property<string>("BookSize")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(3);

                    b.HasDiscriminator().HasValue("BookModel");
                });

            modelBuilder.Entity("Bibliotek.Models.EBookModel", b =>
                {
                    b.HasBaseType("Bibliotek.Models.ProductModel");

                    b.Property<double?>("DataSize")
                        .HasColumnType("float")
                        .HasColumnName("Size(Mb)")
                        .HasColumnOrder(4);

                    b.HasDiscriminator().HasValue("EBookModel");
                });

            modelBuilder.Entity("Bibliotek.Models.MovieModel", b =>
                {
                    b.HasBaseType("Bibliotek.Models.ProductModel");

                    b.Property<string>("Director")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(6);

                    b.Property<int?>("Length")
                        .HasColumnType("int")
                        .HasColumnName("Length(min)")
                        .HasColumnOrder(5);

                    b.HasDiscriminator().HasValue("MovieModel");
                });

            modelBuilder.Entity("Bibliotek.Models.ProductModel", b =>
                {
                    b.HasOne("Bibliotek.Models.UserModel", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bibliotek.Models.ReleaseModel", b =>
                {
                    b.HasOne("Bibliotek.Models.ProductModel", "Product")
                        .WithMany("Releases")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Bibliotek.Models.ProductModel", b =>
                {
                    b.Navigation("Releases");
                });

            modelBuilder.Entity("Bibliotek.Models.UserModel", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
