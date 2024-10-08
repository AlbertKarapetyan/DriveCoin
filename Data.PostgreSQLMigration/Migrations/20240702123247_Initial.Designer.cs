﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.PostgreSQLMigration.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240702123247_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_date");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("email");

                    b.Property<long>("ExternalId")
                        .HasColumnType("bigint")
                        .HasColumnName("external_id");

                    b.Property<bool>("IsPremium")
                        .HasColumnType("boolean")
                        .HasColumnName("is_premium");

                    b.Property<DateTime?>("LastSignedDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("last_signed_date");

                    b.Property<short>("Level")
                        .HasColumnType("smallint")
                        .HasColumnName("level");

                    b.Property<int?>("RefId")
                        .HasColumnType("integer")
                        .HasColumnName("ref_id");

                    b.Property<int?>("RegionId")
                        .HasColumnType("integer")
                        .HasColumnName("region_id");

                    b.Property<string>("UserName")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)")
                        .HasColumnName("user_name");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ExternalId" }, "ix_user_external_id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
