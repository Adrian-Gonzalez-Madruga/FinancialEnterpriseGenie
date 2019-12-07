using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Models
{
    public class GenieDatabase : DbContext
    {
        public DbSet<Credentials> Credentials { get; set; }
        public DbSet<Distributor> Distributors { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<User> Users { get; set; }


        public GenieDatabase(DbContextOptions<GenieDatabase> options) : base(options)
        {


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GenieDb;");
        }
    }
}
