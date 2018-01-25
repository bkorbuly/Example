﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using TestTask.Entities;

namespace TestTask.Migrations
{
    [DbContext(typeof(TransactionContext))]
    [Migration("20180125130401_second")]
    partial class second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestTask.Models.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Amount");

                    b.Property<string>("Destiny");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Source");

                    b.HasKey("ID");

                    b.ToTable("Transactions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Transaction");
                });

            modelBuilder.Entity("TestTask.Models.NewTransaction", b =>
                {
                    b.HasBaseType("TestTask.Models.Transaction");


                    b.ToTable("NewTransaction");

                    b.HasDiscriminator().HasValue("NewTransaction");
                });
#pragma warning restore 612, 618
        }
    }
}
