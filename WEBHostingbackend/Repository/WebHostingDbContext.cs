using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WEBHostingbackend.Repository.Models;

namespace WEBHostingbackend.Repository
{
   // public partial class WebHostingDbContext : DbContext
    public partial class WebHostingDbContext : DbContext
    {
        public WebHostingDbContext()
        {
        }

        public WebHostingDbContext(DbContextOptions<WebHostingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Commande> Commandes { get; set; } = null!;
        public virtual DbSet<Domain> Domains { get; set; } = null!;
        public virtual DbSet<Payement> Payements { get; set; } = null!;
        public virtual DbSet<Serveur> Serveurs { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=Localhost\\SQLEXPRESS;Initial Catalog=WebHosting;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>(entity =>
            {
                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commande_User");

                entity.HasOne(d => d.IdDomaineNavigation)
                    .WithMany(p => p.Commandes)
                    .HasForeignKey(d => d.IdDomaine)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Commande_domaine");
            });

            modelBuilder.Entity<Payement>(entity =>
            {
                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Payements)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Payement_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_User");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserRole");
            });
            modelBuilder.Entity<Serveur>(entity =>
            {
                entity.Property(e => e.IdServeur).ValueGeneratedOnAdd();

                entity.Property(e => e.PlateformeType).IsUnicode(false);

                entity.Property(e => e.HostName).IsUnicode(false);

                entity.Property(e => e.Prix).IsUnicode(false);

                entity.Property(e => e.NbAutorisé).IsUnicode(false);
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
