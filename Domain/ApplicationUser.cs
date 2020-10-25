﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
