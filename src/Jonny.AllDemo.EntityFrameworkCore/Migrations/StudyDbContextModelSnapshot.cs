﻿// <auto-generated />
using System;
using Jonny.AllDemo.EntityFrameworkCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jonny.AllDemo.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(StudyDbContext))]
    partial class StudyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Jonny.AllDemo.EntityFrameworkCore.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Jonny.AllDemo.EntityFrameworkCore.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int")
                        .HasMaxLength(4);

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Like")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<short>("UInt16")
                        .HasColumnType("smallint");

                    b.Property<int>("UInt32")
                        .HasColumnType("int");

                    b.Property<long>("UInt64")
                        .HasColumnType("bigint");

                    b.Property<byte>("Ubyte")
                        .HasColumnType("tinyint");

                    b.Property<string>("Uchar")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<decimal>("Udecimal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("Udouble")
                        .HasColumnType("float");

                    b.Property<float>("Ufloat")
                        .HasColumnType("real");

                    b.Property<long>("Ulong")
                        .HasColumnType("bigint");

                    b.Property<int>("UuInt16")
                        .HasColumnType("int");

                    b.Property<long>("UuInt32")
                        .HasColumnType("bigint");

                    b.Property<decimal>("UuInt64")
                        .HasColumnType("decimal(20,0)");

                    b.Property<long>("Uuint")
                        .HasColumnType("bigint");

                    b.Property<decimal>("Uulong")
                        .HasColumnType("decimal(20,0)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Jonny.AllDemo.EntityFrameworkCore.Models.Users", b =>
                {
                    b.HasOne("Jonny.AllDemo.EntityFrameworkCore.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
