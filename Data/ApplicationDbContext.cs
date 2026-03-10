using CoffeeQueueApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeQueueApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<CoffeeOrder> CoffeeOrder => Set<CoffeeOrder>();
        public DbSet<Barista> Baristas => Set<Barista>();

        //public DbSet<Barista> Baristas { get; set; }
    }
}
