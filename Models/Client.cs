using System;
using System.Collections.Generic;

namespace TP_CRM.Models;

public partial class Client
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool? State { get; set; }

    public decimal? Tva { get; set; }

    public decimal? TotalCaHt { get; set; }

    public string? Comment { get; set; }

    public virtual List<Order> Orders { get; }

    public Client()
    {
        // Orders = new List<Order>();
    }

    public Client(string name, bool state, decimal tva, decimal totalCaHt, string comment)
    {
        this.Name = name;
        this.State = state;
        this.Tva = tva;
        this.TotalCaHt = totalCaHt;
        this.Comment = comment;
        // Orders = new List<Order>();
    }
}
