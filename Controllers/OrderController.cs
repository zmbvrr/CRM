using Microsoft.AspNetCore.Mvc;
using TP_CRM.Models;

namespace TP_CRM.Controllers;

[Route("orders")]
[ApiController]
public class OrderController : ControllerBase
{
	private static CrmContext context = new();

	public OrderController()
	{
	}

	[HttpGet]
	public List<string> GetOrders(int idClient)
	{
		return context.Orders.Where(o => o.IdClient == idClient).Select(o => o.Client.Name).ToList();
	}

	[HttpGet]
    [Route("{id}")]
	public Order Get(int id)
	{
		return context.Orders.Find(id);
	}

	[HttpPost]
    [Route("add")]
	public void Post([FromBody] Order order)
	{
        context.Orders.Add(order);
		context.SaveChanges();
	}

	[HttpPut]
    [Route("edit/{id}")]
	public string Put(int id, [FromBody]Order order)
	{
        try
        {
            Order orderToUpdate = context.Orders.Find(id);
            orderToUpdate.TypePresta = order.TypePresta;
            orderToUpdate.NbJours = order.NbJours;
            orderToUpdate.TjmHt = order.TjmHt;
            orderToUpdate.Tva = order.Tva;
            orderToUpdate.State = order.State;
            orderToUpdate.Comment = order.Comment;
            orderToUpdate.IdClient = order.IdClient;
            context.SaveChanges();
            return "La commande a bien été modifié.";
        }
        catch
        {
            return "Identifiant introuvable...";
        }
	}

	[HttpDelete]
    [Route("{id}")]
	public string Delete (int id)
    {
        try
        {
            var orderToRemove = context.Orders.Find(id);
            context.Orders.Remove(orderToRemove);
            context.SaveChanges();
            return "La commande a bien été supprimée de la liste.";
        }
        catch
        {
            return "Identifiant introuvable, suppression impossible.";
        }
    }  
}