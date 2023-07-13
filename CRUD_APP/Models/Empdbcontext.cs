using System;
using Microsoft.EntityFrameworkCore;

namespace CRUD_APP.Models
{
    public class Empdbcontext : DbContext
    {
        public Empdbcontext(DbContextOptions<Empdbcontext> options) : base(options)
        {

        }
        public DbSet<Employee> Employee { get; set; }
    }
}

