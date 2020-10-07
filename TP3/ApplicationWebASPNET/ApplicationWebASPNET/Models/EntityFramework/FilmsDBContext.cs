using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationWebASPNET.Models.EntityFramework
{
    public class FilmsDBContext : DbContext
    {
        public FilmsDBContext()
        {
        }

        public FilmsDBContext(DbContextOptions<FilmsDBContext> options) : base(options)
        {
        }

        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Favori> Favori { get; set; }
        public virtual DbSet<Film> Film { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.EnableSensitiveDataLogging().UseNpgsql("Server=localhost;port=5432;Database=FilmsDB2;uid=postgres;password=root;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Favori>(entity =>
            {
                entity.HasOne(f => f.FilmFavori)
                      .WithMany(f => f.Favoris)
                      .HasForeignKey(f => f.FilmId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_FAV_FLM");

                entity.HasOne(f => f.CompteFavori)
                      .WithMany(f => f.Favoris)
                      .HasForeignKey(f => f.CompteId)
                      .OnDelete(DeleteBehavior.Restrict)
                      .HasConstraintName("FK_FAV_COM");

                entity.HasKey(e => new { e.FilmId, e.CompteId }).HasName("PK_FAV");
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.HasIndex(c => c.Mel).IsUnique();
                entity.Property(c => c.DateCreation).HasDefaultValue(DateTime.Now);
                entity.Property(c => c.Pays).HasDefaultValue("France");
            });

        }
    }
}
