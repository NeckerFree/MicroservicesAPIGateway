﻿using Microsoft.AspNetCore.Identity;

namespace Identity.Api.Entities
{
    public class AppUser : IdentityUser
    {
        public string? FirstName { get;  set; }
        public string? LastName { get;  set; }
       
    }
}
