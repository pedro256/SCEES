using Microsoft.EntityFrameworkCore;
using SCEES.Domain.Models;
using SCEES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCEES.Persistence
{
    public class ContextDbApp: DbContext
    {
        public ContextDbApp(DbContextOptions<ContextDbApp> options) : base(options)
        {

        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Usuario> User { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

    }
}
