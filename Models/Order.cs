using System;
using System.Collections.Generic;

namespace TP_CRM.Models;

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

    public virtual Client Client { get; set; } = null!;

    public Order()
    {

    }

    public Order(string typePresta, decimal nbJours, decimal tjmHt, decimal tva, string state, string comment, Client client)
    {
        this.TypePresta = typePresta;
        this.NbJours = nbJours;
        this.TjmHt = tjmHt;
        this.Tva = tva;
        this.State = state;
        this.Comment = comment;
        this.Client = client;
        this.IdClient = client.Id;
    }
}
