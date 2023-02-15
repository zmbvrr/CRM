using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TP_CRM.Controllers;

namespace TP_CRM;

public partial class CrmContext : DbContext
{
    public DbSet<Client> Clients { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<User> Users { get; set; }

    public CrmContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
        // Clients.Add(new Client("Air France-KLM", true, 20, 500000, "Compagnie aérienne française"));
        // Clients.Add(new Client("Renault", true, 10, 150000, "Fabricant de voitures et de véhicules utilitaires"));
        // Clients.Add(new Client("Carrefour", true, 20, 250000, "Chaine de supermarchés et d'hypermarchés"));
        // Clients.Add(new Client("TotalEnergies", false, 20, 1000000, "Compagnie pétrolière et gazière française"));
        // Clients.Add(new Client("Société générale", true, 20, 300000, "Banque et institution financière française"));

        // Users.Add(new User("john@example.com", "abc123", "John", "Smith", "abc123", "ADMIN"));
        // Users.Add(new User("sarah@example.com", "def456", "Sarah", "Johnson", "def456", "USER"));
        // Users.Add(new User("mark@example.com", "123abc", "Mark", "Davis", "123abc", "USER"));
        
        // SaveChanges();

    }

    public CrmContext(DbContextOptions<CrmContext> options):base(options)
    {

    }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=LAPTOP-HM1OHB3G;Database=CRM;Trusted_Connection=True;trustServerCertificate=true;");

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__clients__3213E83F7117C129");

            entity.ToTable("clients");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.State)
                .HasDefaultValueSql("((1))")
                .HasColumnName("state");
            entity.Property(e => e.TotalCaHt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("totalCaHt");
            entity.Property(e => e.Tva)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tva");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orders__3213E83F3A56E2FD");

            entity.ToTable("orders");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.NbJours)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("nbJours");
            entity.Property(e => e.State)
                .HasDefaultValueSql("((0))")
                .HasColumnName("state");
            entity.Property(e => e.TjmHt)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tjmHt");
            entity.Property(e => e.Tva)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("tva");
            entity.Property(e => e.TypePresta)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("typePresta");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__orders__idClient__48CFD27E");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83F9B4CF563");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ConfirmedPassword)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("confirmedpassword");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("firstName");
            entity.Property(e => e.Grants)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("grants");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
