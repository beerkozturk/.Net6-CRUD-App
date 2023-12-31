﻿// <auto-generated />
using System;
using CRUD_APP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD_APP.Migrations
{
    [DbContext(typeof(Empdbcontext))]
    [Migration("20230712120423_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("CRUD_APP.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("hiredate")
                        .HasColumnType("TEXT");

                    b.Property<string>("job")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.Property<float?>("salary")
                        .HasColumnType("REAL");

                    b.HasKey("id");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}
