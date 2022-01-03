﻿// <auto-generated />
using System;
using MechanicWebAppAPI.Data.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MechanicWebAppAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220103193547_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Car_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Car_brand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Car_model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Car_reg_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Car_user_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Car_id");

                    b.HasIndex("Car_user_id");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Opinion", b =>
                {
                    b.Property<Guid>("Opinion_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opinion_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Opinion_rate")
                        .HasColumnType("int");

                    b.Property<Guid>("Opinion_user_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Opinion_user_lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opinion_user_name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Opinion_id");

                    b.HasIndex("Opinion_user_id")
                        .IsUnique();

                    b.ToTable("Opinions");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Repair", b =>
                {
                    b.Property<Guid>("Repair_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Repair_cost")
                        .HasColumnType("int");

                    b.Property<string>("Repair_date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Repair_description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Repaired_car_id")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Repair_id");

                    b.HasIndex("Repaired_car_id");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.User", b =>
                {
                    b.Property<Guid>("User_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Token")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("User_confirmed")
                        .HasColumnType("bit");

                    b.HasKey("User_id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Car", b =>
                {
                    b.HasOne("MechanicWebAppAPI.Data.Models.User", "User")
                        .WithMany("Cars")
                        .HasForeignKey("Car_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Opinion", b =>
                {
                    b.HasOne("MechanicWebAppAPI.Data.Models.User", "User")
                        .WithOne("Opinion")
                        .HasForeignKey("MechanicWebAppAPI.Data.Models.Opinion", "Opinion_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Repair", b =>
                {
                    b.HasOne("MechanicWebAppAPI.Data.Models.Car", "Car")
                        .WithMany("Repairs")
                        .HasForeignKey("Repaired_car_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.Car", b =>
                {
                    b.Navigation("Repairs");
                });

            modelBuilder.Entity("MechanicWebAppAPI.Data.Models.User", b =>
                {
                    b.Navigation("Cars");

                    b.Navigation("Opinion");
                });
#pragma warning restore 612, 618
        }
    }
}
