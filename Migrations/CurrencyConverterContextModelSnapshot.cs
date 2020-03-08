﻿// <auto-generated />
using System;
using CurrencyConverter.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurrencyConverter.API.Migrations
{
    [DbContext(typeof(CurrencyConverterContext))]
    partial class CurrencyConverterContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CurrencyConverter.API.Entities.Currency", b =>
                {
                    b.Property<Guid>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CurrencyId");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.ExchangeRate", b =>
                {
                    b.Property<Guid>("ExchangeRateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FromCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Ratio")
                        .HasColumnType("decimal(18,4)");

                    b.Property<Guid?>("ToCurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ExchangeRateId");

                    b.HasIndex("FromCurrencyId");

                    b.HasIndex("ToCurrencyId");

                    b.ToTable("ExchangeRates");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.FromCurrency", b =>
                {
                    b.Property<Guid>("FromCurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FromRelationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FromCurrencyId");

                    b.HasIndex("FromRelationId");

                    b.ToTable("FromCurrencies");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.FromRelation", b =>
                {
                    b.Property<Guid>("CurrencyRelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CurrencyRelationId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("FromRelations");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.ToCurrency", b =>
                {
                    b.Property<Guid>("ToCurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IsoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ToRelationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ToCurrencyId");

                    b.HasIndex("ToRelationId");

                    b.ToTable("ToCurrencies");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.ToRelation", b =>
                {
                    b.Property<Guid>("CurrencyRelationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CurrencyId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CurrencyRelationId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("ToRelations");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.ExchangeRate", b =>
                {
                    b.HasOne("CurrencyConverter.API.Entities.Currency", "FromCurrency")
                        .WithMany("FromRates")
                        .HasForeignKey("FromCurrencyId");

                    b.HasOne("CurrencyConverter.API.Entities.Currency", "ToCurrency")
                        .WithMany("ToRates")
                        .HasForeignKey("ToCurrencyId");
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.FromCurrency", b =>
                {
                    b.HasOne("CurrencyConverter.API.Entities.FromRelation", "FromRelation")
                        .WithMany()
                        .HasForeignKey("FromRelationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.FromRelation", b =>
                {
                    b.HasOne("CurrencyConverter.API.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.ToCurrency", b =>
                {
                    b.HasOne("CurrencyConverter.API.Entities.ToRelation", "ToRelation")
                        .WithMany()
                        .HasForeignKey("ToRelationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CurrencyConverter.API.Entities.ToRelation", b =>
                {
                    b.HasOne("CurrencyConverter.API.Entities.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
