﻿using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WEBHostingbackend.Repository.Models;
using SpeakOut.Entities.Models;

namespace WEBHostingbackend.Repository
{
   // public partial class WebHostingDbContext : DbContext
    public partial class WebHostingDbContext : IdentityDbContext<AspNetUsers, AspNetRoles,Guid>
    {
        public WebHostingDbContext()
        {
        }

        public WebHostingDbContext(DbContextOptions<WebHostingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<Commande> Commande { get; set; } = null!;
        public virtual DbSet<Domain> Domain { get; set; } = null!;
        public virtual DbSet<Payement> Payement { get; set; } = null!;
        public virtual DbSet<Serveur> Serveurs { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;
        public DbSet<AspNetUsers> ApplicationUser { get; set; }

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
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
            modelBuilder.Entity<IdentityUserLogin<Guid>>().HasKey(p => new { p.LoginProvider, p.UserId });
            modelBuilder.Entity<IdentityUser>();
           
            modelBuilder.Entity<Payement>(entity =>
            {
                entity.Property(e => e.idPayement).ValueGeneratedOnAdd();

                entity.Property(e => e.Type).IsUnicode(false);

                entity.Property(e => e.Date).IsUnicode(false);

                entity.Property(e => e.Status).IsUnicode(false);

                
            });
            modelBuilder.Entity<Domain>(entity =>
            {
                entity.Property(e => e.IdDomain).ValueGeneratedOnAdd();

                entity.Property(e => e.DomainName).IsUnicode(false);

                entity.Property(e => e.Root).IsUnicode(false);

                entity.Property(e => e.HebergementType).IsUnicode(false);
                entity.Property(e => e.DateCreation).IsUnicode(false);


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

                entity.Property(e => e.NbAutorise).IsUnicode(false);
            });
            modelBuilder.Entity<Commande>(entity =>
            {
                entity.Property(e => e.IdCommande).ValueGeneratedOnAdd();
                entity.HasIndex(e => e.IdCommande);

                

               entity.HasKey(e => e.IdCommande)
                    .HasName("PK_Commande");
                entity.HasOne(d => d.Serv)
                .WithMany(p => p.Commandes)
                .HasForeignKey(d => d.IdService)
                .HasConstraintName("FK_Commande_Service_id_service");

               

            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
