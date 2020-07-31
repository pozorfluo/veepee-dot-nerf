using Microsoft.EntityFrameworkCore;
using VeepeeDotNerf.Models;

namespace VeepeeDotNerf.Data
{
  public class VeepeeDotNerfContext : DbContext
  {
    public VeepeeDotNerfContext (DbContextOptions<VeepeeDotNerfContext> options) : base (options)
    { }

    public DbSet<Address> Addresses
    {
      get;
      set;
    }
    public DbSet<Client> Clients
    {
      get;
      set;
    }
  }
}