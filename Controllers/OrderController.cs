using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TP_CRM;

namespace TP_CRM.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
	private static CrmContext context = new();

    public readonly JwtAuthenticationManager jwtAuthenticationManager;

    public OrderController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        this.jwtAuthenticationManager = jwtAuthenticationManager;
    }

	[Authorize]
    [HttpGet]
	public List<Order> GetOrders()
	{
		// return context.Orders.Where(o => o.IdClient == idClient).Select(o => o.Client.Name).ToList();
        return context.Orders.ToList();
	}

	[Authorize]
    [HttpGet]
    [Route("{id}")]
	public Order Get(int id)
	{
		return context.Orders.Find(id);
	}

    [Authorize]
	[HttpPost]
    [Route("add")]
	public void Post(Order order)
	{     
        context.Orders.Add(order);
		context.SaveChanges();
	}

    [Authorize]
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

    [Authorize]
	[HttpDelete]
    [Route("{id}")]
	public string Delete (int id)
    {
        try
        {
            Order orderToRemove = context.Orders.Find(id);
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