using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MarvelEntity.Entity
{
    public class ExamDbContext: DbContext
    {
        public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options) { }
        public virtual DbSet<Cinema> Cinemas { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<TheaterType> TheaterTypes { get; set; }
        public virtual DbSet<Blob> Blobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Cinema>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("cinema_pkey");

                entity.HasMany<Theater>(e => e.ListOfTheaters)
                .WithOne(e => e.Cinema)
                .HasConstraintName("t__theater_fkey")
                .IsRequired();

                entity.HasOne(e => e.Blob)
                .WithMany(e => e.ListOfCinemas)
                .HasForeignKey(e => e.BlobId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("u__blob_id_fkey");
            });

            modelBuilder.Entity<Theater>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("theater_pkey");

                entity.HasOne(e => e.TheaterType)
                .WithMany(e => e.ListOfTheaters)
                .HasForeignKey(e => e.TheaterTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("t__theatertype_id_fkey")
                .IsRequired();
            });

            modelBuilder.Entity<Blob>(entity =>
            {
                entity.HasKey(e => e.BlobId)
                .HasName("blob_pkey");
            });
        }



    }
}
