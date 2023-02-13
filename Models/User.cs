using System;
using System.Collections.Generic;

namespace TP_CRM.Models;

public partial class User
{
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public string ConfirmedPassword { get; set; } = null!;

    public string? Grants { get; set; }

    public User()
    {

    }

    public User(string email, string password, string firstname, string lastname, string confirmedPassword, string grants)
    {
        this.Email = email;
        this.Password = password;
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.ConfirmedPassword = confirmedPassword;
        this.Grants = grants;
    }
}
