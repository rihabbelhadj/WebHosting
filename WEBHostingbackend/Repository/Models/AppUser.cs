﻿using System;
using Microsoft.AspNetCore.Identity;
namespace WEBHostingbackend.Repository.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get;set; }
        public DateTime  DateCreated { get;set; }
        public DateTime  DateModified { get;set; }
    }
}
     