﻿// <auto-generated />
using System;
using BankRepository.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BankRepository.Migrations
{
    [DbContext(typeof(BankContext))]
    [Migration("20190604115850_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("BankRepository.Models.Bank", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Banks");

                    b.HasData(
                        new { Id = 1, Name = "FNB" }
                    );
                });

            modelBuilder.Entity("BankRepository.Models.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountHolder");

                    b.Property<string>("AccountNumber");

                    b.Property<int?>("BankId");

                    b.Property<int>("BranchCode");

                    b.Property<string>("BranhName");

                    b.HasKey("Id");

                    b.HasIndex("BankId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("BankRepository.Models.BankAccount", b =>
                {
                    b.HasOne("BankRepository.Models.Bank", "Bank")
                        .WithMany()
                        .HasForeignKey("BankId");
                });
#pragma warning restore 612, 618
        }
    }
}
