﻿// <auto-generated />

using EFCore.MigrationExtensions.SqlObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TestDataAccessLayer;

namespace TestDataAccessLayer.Migrations
{
    [DbContext(typeof(TestContext))]
    [Migration("20221003105505_MyMigr2")]
    partial class MyMigr2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.Model.AddSqlObjects(new SqlObject[]
            {
                new("v_view_10", "create or replace view migr_ext_tests.v_view_10 as select * from migr_ext_tests.my_table;")
                {
                    Order = 10
                },
                new("v_view_2.sql", "create or replace view migr_ext_tests.name123_2 as select * from migr_ext_tests.my_table;")
                {
                    Order = 2147483647
                },
                new("v_view.sql", "create or replace view migr_ext_tests.name123 as select * from migr_ext_tests.my_table;")
                {
                    Order = 2147483647
                },
            });

            modelBuilder
                .HasDefaultSchema("migr_ext_tests")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("TestDataAccessLayer.Class1", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.HasKey("Id");

                    b.ToTable("my_table");
                });
#pragma warning restore 612, 618
        }
    }
}
