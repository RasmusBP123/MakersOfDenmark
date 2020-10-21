﻿// <auto-generated />
using System;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(SqlContext))]
    [Migration("20201021093323_i")]
    partial class i
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CalendarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Domain.Calendar", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Calendars");
                });

            modelBuilder.Entity("Domain.Workshop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<Guid>("CalendarId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CvrNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("SchooldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CalendarId")
                        .IsUnique();

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("Domain.Activity", b =>
                {
                    b.HasOne("Domain.Calendar", "Calendar")
                        .WithMany("Activities")
                        .HasForeignKey("CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Workshop", b =>
                {
                    b.HasOne("Domain.Calendar", "Calendar")
                        .WithOne("Workshop")
                        .HasForeignKey("Domain.Workshop", "CalendarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Domain.ValueObjects.Location", "Location", b1 =>
                        {
                            b1.Property<Guid>("WorkshopId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .HasColumnName("Address")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Zipcode")
                                .HasColumnName("Zipcode")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WorkshopId");

                            b1.ToTable("Workshops");

                            b1.WithOwner()
                                .HasForeignKey("WorkshopId");
                        });

                    b.OwnsOne("Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("WorkshopId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Number")
                                .HasColumnName("Number")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("WorkshopId");

                            b1.ToTable("Workshops");

                            b1.WithOwner()
                                .HasForeignKey("WorkshopId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
