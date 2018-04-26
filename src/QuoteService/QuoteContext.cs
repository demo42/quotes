using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteService
{
    public class QuoteContext : DbContext
    {
        public QuoteContext(DbContextOptions<QuoteContext> options)
            : base(options)
        {

        }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Quote>()
                   .HasData(new Quote { Id=1,Attribution="Steve Lasker", Text="The network is always reliable." });
        }
    }
}
