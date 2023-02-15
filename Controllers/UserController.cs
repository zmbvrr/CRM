using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_CRM;

namespace TP_CRM.Controllers;

[Route("users")]
[ApiController]
public class UserController : ControllerBase
{
    public static CrmContext context = new ();

    public readonly JwtAuthenticationManager jwtAuthenticationManager;

    public UserController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        this.jwtAuthenticationManager = jwtAuthenticationManager;
    }


    [Authorize]
    [HttpGet]
    public List<User> GetUsers()
    {
        return context.Users.ToList();
    }

    [Authorize]
    [HttpGet]
    [Route("{id}")]
    public User Get(int id)
    {
        return context.Users.Find(id);
        
    }

    [Authorize]
    [HttpPost]
    [Route("add")]
    public void Post(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    [Authorize]
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

    [Authorize]
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
