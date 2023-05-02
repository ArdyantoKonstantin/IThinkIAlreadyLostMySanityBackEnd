﻿// <auto-generated />
using System;
using MarvelEntity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarvelEntity.Migrations
{
    [DbContext(typeof(ExamDbContext))]
    [Migration("20230502115209_Initial1")]
    partial class Initial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MarvelEntity.Entity.Blob", b =>
                {
                    b.Property<Guid>("BlobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("blob_id");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_name");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("file_path");

                    b.Property<string>("MIME")
                        .HasColumnType("text")
                        .HasColumnName("mime");

                    b.HasKey("BlobId")
                        .HasName("blob_pkey");

                    b.ToTable("blobs", "public");
                });

            modelBuilder.Entity("MarvelEntity.Entity.Cinema", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("address");

                    b.Property<Guid?>("BlobId")
                        .IsRequired()
                        .HasColumnType("uuid")
                        .HasColumnName("blob_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("cinema_pkey");

                    b.HasIndex("BlobId")
                        .HasDatabaseName("ix_cinemas_blob_id");

                    b.ToTable("cinemas", "public");
                });

            modelBuilder.Entity("MarvelEntity.Entity.Theater", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CinemaId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cinema_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("TheaterTypeId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("theater_type_id");

                    b.HasKey("Id")
                        .HasName("theater_pkey");

                    b.HasIndex("CinemaId")
                        .HasDatabaseName("ix_theaters_cinema_id");

                    b.HasIndex("TheaterTypeId")
                        .HasDatabaseName("ix_theaters_theater_type_id");

                    b.ToTable("theaters", "public");
                });

            modelBuilder.Entity("MarvelEntity.Entity.TheaterType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_theater_types");

                    b.ToTable("theater_types", "public");
                });

            modelBuilder.Entity("MarvelEntity.Entity.Cinema", b =>
                {
                    b.HasOne("MarvelEntity.Entity.Blob", "Blob")
                        .WithMany("ListOfCinemas")
                        .HasForeignKey("BlobId")
                        .IsRequired()
                        .HasConstraintName("u__blob_id_fkey");

                    b.Navigation("Blob");
                });

            modelBuilder.Entity("MarvelEntity.Entity.Theater", b =>
                {
                    b.HasOne("MarvelEntity.Entity.Cinema", "Cinema")
                        .WithMany("ListOfTheaters")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("t__theater_fkey");

                    b.HasOne("MarvelEntity.Entity.TheaterType", "TheaterType")
                        .WithMany("ListOfTheaters")
                        .HasForeignKey("TheaterTypeId")
                        .IsRequired()
                        .HasConstraintName("t__theatertype_id_fkey");

                    b.Navigation("Cinema");

                    b.Navigation("TheaterType");
                });

            modelBuilder.Entity("MarvelEntity.Entity.Blob", b =>
                {
                    b.Navigation("ListOfCinemas");
                });

            modelBuilder.Entity("MarvelEntity.Entity.Cinema", b =>
                {
                    b.Navigation("ListOfTheaters");
                });

            modelBuilder.Entity("MarvelEntity.Entity.TheaterType", b =>
                {
                    b.Navigation("ListOfTheaters");
                });
#pragma warning restore 612, 618
        }
    }
}
