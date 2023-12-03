﻿// <auto-generated />
using System;
using GorimoozeWallet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GorimoozeWallet.Migrations
{
    [DbContext(typeof(GorimoozeWalletDbContext))]
    [Migration("20231203020042_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GorimoozeWallet.Models.Currency", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<byte[]>("ImageData")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateActivity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Currency");
                });

            modelBuilder.Entity("GorimoozeWallet.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("GorimoozeWallet.Models.Wallet", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("CurrencyId")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsLocked")
                        .HasColumnType("bit");

                    b.Property<double?>("Score")
                        .HasColumnType("float");

                    b.Property<string>("WalletNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "CurrencyId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Wallet");
                });

            modelBuilder.Entity("GorimoozeWallet.Models.Wallet", b =>
                {
                    b.HasOne("GorimoozeWallet.Models.Currency", "Currency")
                        .WithMany("Wallets")
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GorimoozeWallet.Models.User", "User")
                        .WithMany("Wallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GorimoozeWallet.Models.Currency", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("GorimoozeWallet.Models.User", b =>
                {
                    b.Navigation("Wallets");
                });
#pragma warning restore 612, 618
        }
    }
}