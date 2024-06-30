using krakent_cryptus_user.domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace krakent_cryptus_user.infrastructure.database.context
{

    public class PostgreSqlContext(DbContextOptions<PostgreSqlContext> options) : DbContext(options)
    {

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RolEntity> Rols { get; set; }
        public DbSet<UserRolEntity> UserRols { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRolEntity>()
            .HasKey(ur => new { ur.UserId, ur.RolId });

            modelBuilder.Entity<UserRolEntity>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRols)
            .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRolEntity>()
            .HasOne(ur => ur.Rol)
            .WithMany(r => r.UserRols)
            .HasForeignKey(ur => ur.RolId);

            modelBuilder.Entity<UserEntity>()
            .HasMany(u => u.UserRols)
            .WithOne(ur => ur.User)
            .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<RolEntity>()
            .HasMany(r => r.UserRols)
            .WithOne(ur => ur.Rol)
            .HasForeignKey(ur => ur.RolId);

            modelBuilder.Entity<UserEntity>()
            .Property(u => u.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<RolEntity>()
            .Property(r => r.Id)
            .ValueGeneratedOnAdd();

            modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Identification)
            .IsUnique();

            modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Email)
            .IsUnique();

            modelBuilder.Entity<UserEntity>()
            .HasIndex(u => u.Username)
            .IsUnique();

            modelBuilder.Entity<RolEntity>()
            .HasIndex(r => r.Name)
            .IsUnique();

            modelBuilder.Entity<RolEntity>()
            .HasIndex(r => r.Acronym)
            .IsUnique();

            modelBuilder.Entity<UserEntity>()
            .Property(u => u.CreationDate)
            .HasDefaultValueSql("now()");

        }
    }
}
