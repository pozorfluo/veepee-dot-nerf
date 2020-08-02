using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VeepeeDotNerf.Data;
using System;
using System.Linq;

namespace VeepeeDotNerf.Models
{
  public static class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new VeepeeDotNerfContext(
        serviceProvider.GetRequiredService<DbContextOptions<VeepeeDotNerfContext>>()))
        {
          // Abort if DB has already been seeded.
          if (context.Address.Any()) { return; }

          context.Address.AddRange(
            new Address {
              type = "billing",
              firstName = "Jean",
              lastName = "Pull",
              email = "moul@ga.com",
              line1 = "7, Sieben Moula",
              line2 = "",
              city = "Roanne",
              zipCode = "42000",
              country = "France",
              phone = "+33 12345678",
            },
            new Address {
              type = "shipping",
              firstName = "Jean",
              lastName = "Pull",
              email = "moul@ga.com",
              line1 = "7, Sieben Moula",
              line2 = "",
              city = "Roanne",
              zipCode = "42000",
              country = "France",
              phone = "+33 12345678",
            }
          );
          context.SaveChanges();

        }
    }
  }
}