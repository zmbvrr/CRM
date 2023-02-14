using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_CRM.Models;

namespace TP_CRM.Controllers;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    public static CrmContext context = new ();

    public UserController()
    {

    }

    [HttpGet]
    public List<User> Get()
    {
        return context.Users.ToList();
    }

    [HttpGet]
    [Route("{id}")]
    public User Get(int id)
    {
        return context.Users.Find(id);
        
    }

    [HttpPost]
    [Route("add")]
    public void Post(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    [HttpPut]
    [Route("edit/{id}")]
    public string Put(int id, [FromBody] User user)
    {
        try
        {
            User userToUpdate = context.Users.Find(id);
            userToUpdate.Email = user.Email;
            userToUpdate.Password = user.Password;
            userToUpdate.Firstname = user.Firstname;
            userToUpdate.Lastname = user.Lastname;
            userToUpdate.ConfirmedPassword = user.ConfirmedPassword;
            userToUpdate.Grants = user.Grants;
            context.SaveChanges();
            return "L'utilisateur a bien été modifié.";
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
            var userToRemove = context.Users.Find(id);
            context.Users.Remove(userToRemove);
            context.SaveChanges();
            return "L'utilisateur a bien été supprimé de la liste.";
        }
        catch
        {
            return "Identifiant introuvable, suppression impossible.";
        }
    }   
}
