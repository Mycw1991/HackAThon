using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HackAThon.Models;

namespace HackAThon.DBContexts
{
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options): base(options)
        {
        }

        public DbSet<Person> Person{ get; set; }
    }
}
