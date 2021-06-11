using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public class PrecixWeightDbContext : DbContext
    {
        public PrecixWeightDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeighingSheetDetails>().HasKey(wsd => new { wsd.WeighingSheetDetailsProductId, wsd.WeighingSheetDetailsWeighingSheetId });
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<WeighingSheet> WeighingSheet { get; set; }
        public DbSet<WeighingSheetDetails> WeighingSheetDetails { get; set; }
    }
}
