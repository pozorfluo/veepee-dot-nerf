using Microsoft.EntityFrameworkCore;
using VeepeeDotNerf.Models;

namespace VeepeeDotNerf.Data
{
  public class VeepeeDotNerfContext : DbContext
  {

    public VeepeeDotNerfContext(DbContextOptions<VeepeeDotNerfContext> options)
      : base(options)
    {
    }

    public DbSet<Address> Address { get; set; }
    public DbSet<Client> Client { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Country> Country { get; set; }
    public DbSet<Order> Order { get; set; }

    // // not neeeded for this project.
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //   modelBuilder.Entity<Client>()
    //     .HasIndex(c => c.email)
    //       .IsUnique();
    // }
  }
}
