using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_CRM.Models;

namespace TP1.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    public static CrmContext context = new ();
    public static List<User> Users = context.Users.ToList();

    public UserController()
    {

    }

    // [HttpGet]
    // public List<User> Get()
    // {
    //     return Users;
    // }

    [HttpGet]
    [Route("{id}")]
    public IActionResult Get(int id)
    {
        var userTempo = Users[id - 1];

        if (userTempo != null)
        {
            return Ok(userTempo);
        }
        else
        {
            return NotFound($"L'utilisateur avec l'id {id} est introuvable.");
        }
    }

    [HttpPost]
    [Route("Add")]
    public List<User> Post([FromBody] User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return context.Users.ToList();
    }

    [HttpPut]
    [Route("edit/{id}")]
    public string Put([FromBody] User user)
    {
        try
        {
            User tempo = context.Users.Find(user.Id);
            tempo.Email = user.Email;
            tempo.Password = user.Password;
            tempo.Firstname = user.Firstname;
            tempo.Lastname = user.Lastname;
            tempo.ConfirmedPassword = user.ConfirmedPassword;
            tempo.Grants = user.Grants;
            context.SaveChanges();
            return "L'utilisateur a bien été modifié.";
        }
        catch
        {
            return "Identifiant introuvable...";
        }

    }

    // [HttpDelete]
    // [Route("{id}")]
    // public string Delete (int id)
    // {
    //     try
    //     {
    //         User tempo = context.Users.Find(id);
    //         context.Users.Remove(tempo);
    //         context.SaveChanges();
    //         return "L'utilisateur a bien été supprimé de la liste.";
    //     }
    //     catch
    //     {
    //         return "Identifiant introuvable, suppression impossible.";
    //     }
    // }   
}
