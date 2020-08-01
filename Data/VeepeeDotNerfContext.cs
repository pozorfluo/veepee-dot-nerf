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
  }
}
