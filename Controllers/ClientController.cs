using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TP_CRM;

namespace TP_CRM.Controllers;

[ApiController]
[Route("clients")]

public class ClientController : ControllerBase
{
	private static CrmContext context = new();

    public readonly JwtAuthenticationManager jwtAuthenticationManager;

    public ClientController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        this.jwtAuthenticationManager = jwtAuthenticationManager;
    }

    [Authorize]
	[HttpGet]
	public List<Client> GetClients()
	{
		return context.Clients.ToList();
	}

    [Authorize]
	[HttpGet]
    [Route("{id}")]
	public Client Get(int id)
	{
		return context.Clients.Find(id);
	}

    [Authorize]
	[HttpPost]
    [Route("add")]
	public void Post(Client client)
	{
		context.Clients.Add(client);
		context.SaveChanges();
	}

    [Authorize]
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

    [Authorize]
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
            return "Suppression impossible.";
        }
    }  
}