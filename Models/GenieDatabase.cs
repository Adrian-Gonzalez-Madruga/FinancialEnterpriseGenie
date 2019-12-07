using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FinancialEnterpriseGenie.Models
{
    public class GenieDatabase : DbContext
    {

        public GenieDatabase(DbContextOptions<GenieDatabase> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GenieDb;");
        }
    }
}
