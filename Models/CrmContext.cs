using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TP_CRM.Controllers;

namespace TP_CRM.Models;

public partial class CrmContext : DbContext
{
    public CrmContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
        // Client AirFrance = new Client("Air France-KLM", true, 20, 500000, "Compagnie aérienne française");
        // HomeController.context.Clients.Add(AirFrance);
        // Client Renault = new Client("Renault", true, 10, 150000, "Fabricant de voitures et de véhicules utilitaires");
        // HomeController.context.Clients.Add(Renault);
        // Client Carrefour = new Client("Carrefour", true, 20, 250000, "Chaine de supermarchés et d'hypermarchés");
        // HomeController.context.Clients.Add(Carrefour);
        // Client Total = new Client("TotalEnergies", false, 20, 1000000, "Compagnie pétrolière et gazière française");
        // HomeController.context.Clients.Add(Total);
        // Client SocieteGenerale = new Client("Société générale", true, 20, 300000, "Banque et institution financière française");
        // HomeController.context.Clients.Add(SocieteGenerale);

        
        // Order order1 = new Order("Développement web", 10, 1200, 20, "CONFIRMED", "Création d'un site de commerce électronique", Carrefour);
        // HomeController.context.Orders.Add(order1);
        // Order order2 = new Order("Formation", 7, 800, 10, "OPTION", "Formation sur les dernières technologies en matière de sécurité informatique", AirFrance);
        // HomeController.context.Orders.Add(order2);
        // Order order3 = new Order("Audit", 3, 1500, 20, "CONFIRMED", "Audit de sécurité pour une banque régionale", SocieteGenerale);
        // HomeController.context.Orders.Add(order3);
        // Order order4 = new Order("Développement mobile", 14, 1000, 20, "OPTION", "Développement d'une application de suivi de la santé pour les patients atteints du cancer", Carrefour);
        // HomeController.context.Orders.Add(order4);
        // Order order5 = new Order("Consulting", 5, 2000, 20, "CONFIRMED", "Conseil en matière de strétégie d'entreprise et de développement de produits", Renault);
        // HomeController.context.Orders.Add(order5);


        // User John = new User("john@example.com", "abc123", "John", "Smith", "abc123", "ADMIN");
        // HomeController.context.Users.Add(John);
        // User Sarah = new User("sarah@example.com", "def456", "Sarah", "Johnson", "def456", "USER");
        // HomeController.context.Users.Add(Sarah);
        // User Mark = new User("mark@example.com", "123abc", "Mark", "Davis", "123abc", "USER");
        // HomeController.context.Users.Add(Mark);
        
        // SaveChanges();

    }

    public CrmContext(DbContextOptions<CrmContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=LAPTOP-HM1OHB3G;Database=CRM;Trusted_Connection=True;trustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // définition des clés primaires
        modelBuilder.Entity<Client>().HasKey(c => c.Id);
        modelBuilder.Entity<Order>().HasKey(o => o.Id);
        modelBuilder.Entity<User>().HasKey(u => u.Id);


        // one-to-many entre order et client
        modelBuilder.Entity<Order>()
        .HasOne<Client> (o => o.Client)
        .WithMany(c => c.Orders)
        .HasForeignKey(o => o.IdClient);

    }
}