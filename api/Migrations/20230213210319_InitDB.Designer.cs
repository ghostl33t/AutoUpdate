﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using server.Database;

#nullable disable

namespace api.Migrations
{
    [DbContext(typeof(DBMainContext))]
    [Migration("20230213210319_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("api.Models.Domain.SetupUpdate", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<short>("ClearDLLTableMinutes")
                        .HasColumnType("smallint");

                    b.Property<string>("DLLServerPath")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<string>("OtherServerPath")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar");

                    b.Property<short>("RepeatUpdateMinutes")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("SetupUpdate");
                });

            modelBuilder.Entity("api.Models.Domain.UpdateObject", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<short>("AssemblyType")
                        .HasColumnType("smallint");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar");

                    b.Property<short>("FileType")
                        .HasColumnType("smallint");

                    b.Property<string>("FileVersion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar");

                    b.Property<short>("UpdateFile")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("UpdateObjects");
                });
#pragma warning restore 612, 618
        }
    }
}