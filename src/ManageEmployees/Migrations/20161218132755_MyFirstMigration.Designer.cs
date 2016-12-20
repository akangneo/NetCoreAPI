﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ManageEmployees.Data;
using ManageEmployees.Models.Enums;

namespace ManageEmployees.Migrations
{
    [DbContext(typeof(ManageEmployeesContext))]
    [Migration("20161218132755_MyFirstMigration")]
    partial class MyFirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManageEmployees.Models.Entities.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("EmployeeId");

                    b.Property<DateTime>("EndDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 12, 18, 14, 27, 55, 154, DateTimeKind.Local));

                    b.Property<DateTime>("StartDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 12, 18, 14, 27, 55, 154, DateTimeKind.Local));

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Contract");
                });

            modelBuilder.Entity("ManageEmployees.Models.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("ManageEmployees.Models.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Age");

                    b.Property<DateTime>("BirthDate")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(new DateTime(2016, 12, 18, 14, 27, 55, 121, DateTimeKind.Local));

                    b.Property<int>("DepartmentId");

                    b.Property<string>("FirstName");

                    b.Property<int>("JobPosition")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue(2);

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("ManageEmployees.Models.Entities.Contract", b =>
                {
                    b.HasOne("ManageEmployees.Models.Entities.Employee", "Employee")
                        .WithMany("Contracts")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("ManageEmployees.Models.Entities.Employee", b =>
                {
                    b.HasOne("ManageEmployees.Models.Entities.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId");
                });
        }
    }
}