using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BillionareApi.Models
{
    public class BillionareContext : DbContext
    {
        public BillionareContext(DbContextOptions<BillionareContext> options) : base(options)
        {

        }
        public DbSet<Billionare> Billionare { get; set; }
        public DbSet<BillionareAccomplishment> BillionareAccomplishment { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<BillionareIncomeSource> BillionareIncomeSource { get; set; }
        public DbSet<Pronoun> Pronoun { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
