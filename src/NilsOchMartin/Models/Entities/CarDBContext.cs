using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NilsOchMartin.Models.Entities
{
    public partial class CarDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.Property(e => e.Brand)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<Owner>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(max)");
            });

            modelBuilder.Entity<OwnerCarRelations>(entity =>
            {
                entity.HasKey(e => new { e.OwnerId, e.CarId })
                    .HasName("PK_OwnerCar_Relations");

                entity.Property(e => e.OwnerId).HasColumnName("Owner_ID");

                entity.Property(e => e.CarId).HasColumnName("Car_ID");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.OwnerCarRelations)
                    .HasForeignKey(d => d.CarId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OwnerCar_Relations2Car");

                entity.HasOne(d => d.Owner)
                    .WithMany(p => p.OwnerCarRelations)
                    .HasForeignKey(d => d.OwnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_OwnerCar_Relations2Owner");
            });
        }

        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<Owner> Owner { get; set; }
        public virtual DbSet<OwnerCarRelations> OwnerCarRelations { get; set; }
    }
}