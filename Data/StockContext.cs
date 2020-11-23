using web.Models;
using Microsoft.EntityFrameworkCore;

namespace web.Data
{
    public class StockContext : DbContext
    {
        public StockContext(DbContextOptions<StockContext> options) : base(options)
        {
        }

        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Stock2> Stocks2 { get; set; }
        public DbSet<Stock3> Stocks3 { get; set; }
        public DbSet<Stock4> Stocks4 { get; set; }
        public DbSet<Stock5> Stocks5 { get; set; }

       
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>().ToTable("Stock");
            modelBuilder.Entity<Stock2>().ToTable("Stock2");
            modelBuilder.Entity<Stock3>().ToTable("Stock3");
            modelBuilder.Entity<Stock4>().ToTable("Stock4");
            modelBuilder.Entity<Stock5>().ToTable("Stock5");
            
        }
    }
}