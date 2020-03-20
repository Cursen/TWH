using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TWH.Entities.Models;

namespace TWH.Entities.DBConfig
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions options) : base(options)
        {
        }
    protected override void OnConfiguring
        (DbContextOptionsBuilder optionsBuilder)
        { }
        //TODO set up the options builde to use the proper values.
    }
}
