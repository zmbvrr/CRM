using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_CRM;

namespace TP_CRM.Controllers;

[ApiController]
public class AuthenticationController : ControllerBase
{
    public readonly JwtAuthenticationManager jwtAuthenticationManager;

    public AuthenticationController(JwtAuthenticationManager jwtAuthenticationManager)
    {
        this.jwtAuthenticationManager = jwtAuthenticationManager;
    }

    [AllowAnonymous]
    [HttpPost("Authorize")]
    public string AuthenticateUser([FromBody] User user)
    {
        var token = jwtAuthenticationManager.Authenticate(user.Email, user.Password);
        if (token == null)
        {
            return "Non autorisé";
        }
        return token;
    }
}
