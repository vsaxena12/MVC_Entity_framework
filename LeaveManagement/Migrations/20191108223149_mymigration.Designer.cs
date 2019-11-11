﻿// <auto-generated />
using LeaveManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeaveManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191108223149_mymigration")]
    partial class mymigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LeaveManagement.Models.Leave", b =>
                {
                    b.Property<int>("LeaveID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LeaveReason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeaveStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeaveTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Noofdays")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("LeaveID");

                    b.ToTable("leave");
                });

            modelBuilder.Entity("LeaveManagement.Models.LeaveTypeClass", b =>
                {
                    b.Property<int>("LeaveTypeID")
                        .HasColumnType("int");

                    b.Property<string>("LeaveType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaveTypeID");

                    b.ToTable("leaveTypeClass");
                });

            modelBuilder.Entity("LeaveManagement.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("user");
                });

            modelBuilder.Entity("LeaveManagement.Models.LeaveTypeClass", b =>
                {
                    b.HasOne("LeaveManagement.Models.Leave", "Leave")
                        .WithMany()
                        .HasForeignKey("LeaveTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LeaveManagement.Models.User", b =>
                {
                    b.HasOne("LeaveManagement.Models.Leave", "Leave")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
