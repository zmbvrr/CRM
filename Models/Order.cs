using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TP_CRM;

public partial class Order
{
    public int Id { get; set; }

    public string TypePresta { get; set; } = null!;

    public decimal? NbJours { get; set; }

    public decimal? TjmHt { get; set; }

    public decimal? Tva { get; set; }

    public string? State { get; set; }

    public string? Comment { get; set; }


    public int IdClient { get; set; }

    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual Client? Client { get; set; }

    public Order()
    {

    }

    public Order(string typePresta, decimal nbJours, decimal tjmHt, decimal tva, string state, string comment, int idClient)
    {
        this.TypePresta = typePresta;
        this.NbJours = nbJours;
        this.TjmHt = tjmHt;
        this.Tva = tva;
        this.State = state;
        this.Comment = comment;
        this.IdClient = idClient;
        // this.Client = client;
        Client.Orders.Add(this);
    }
}
