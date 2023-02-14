using Microsoft.AspNetCore.Mvc;
using TP_CRM.Models;

namespace TP_CRM.Controllers;

[Route("clients")]
[ApiController]
public class ClientController : ControllerBase
{
	private static CrmContext context = new();

	public ClientController()
	{
	}

	[HttpGet]
	public List<string> GetClients()
	{
		return context.Clients.Select(c => c.Name).ToList();
	}

	[HttpGet]
    [Route("{id}")]
	public Client Get(int id)
	{
		return context.Clients.Find(id);
	}

	[HttpPost]
    [Route("add")]
	public void Post(Client client)
	{
		context.Clients.Add(client);
		context.SaveChanges();
	}

	[HttpPut]
    [Route("edit/{id}")]
	public string Put(int id, [FromBody]Client client)
	{
        try
        {
            Client clientToUpdate = context.Clients.Find(id);
            clientToUpdate.Name = client.Name;
            clientToUpdate.State = client.State;
            clientToUpdate.Tva = client.Tva;
            clientToUpdate.TotalCaHt = client.TotalCaHt;
            clientToUpdate.Comment = client.Comment;
            context.SaveChanges();
            return "Le client a bien été modifié.";
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
            var clientToRemove = context.Clients.Find(id);
            context.Clients.Remove(clientToRemove);
            context.SaveChanges();
            return "Le client a bien été supprimé de la liste.";
        }
        catch
        {
            return "Identifiant introuvable, suppression impossible.";
        }
    }  
}