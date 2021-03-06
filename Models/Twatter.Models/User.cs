﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Twatter.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual User Follower { get; set; }
        public virtual User Followee { get; set; }
        public ICollection<Twatt> FavouriteTwatts { get; set; }
        public ICollection<Twatt> Twatts { get; set; }
        [InverseProperty("Followee")]
        public ICollection<User> Following { get; set; }
        [InverseProperty("Follower")]
        public ICollection<User> Followers { get; set; }
        
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
