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
        if (!context.Country.Any())
        {

          context.Country.AddRange(
            new Country
            {
              name = "France",
            },
            new Country
            {
              name = "Belgique",
            },
            new Country
            {
              name = "Luxembourg",
            }
          );
        }

        // if (!context.Address.Any())
        // {
        //   context.Address.AddRange(
        //     new Address
        //     {
        //       type = "billing",
        //       firstName = "Jean",
        //       lastName = "Pull",
        //       email = "moul@ga.com",
        //       line1 = "7, Sieben Moula",
        //       line2 = "",
        //       city = "Roanne",
        //       zipCode = "42000",
        //       countryForeignKey = 1,
        //       phone = "+33 12345678",
        //     },
        //     new Address
        //     {
        //       type = "shipping",
        //       firstName = "Jean",
        //       lastName = "Pull",
        //       email = "moul@ga.com",
        //       line1 = "7, Sieben Moula",
        //       line2 = "",
        //       city = "Roanne",
        //       zipCode = "42000",
        //       countryForeignKey = 1,
        //       phone = "+33 12345678",
        //     }
        //   );
        // }

        if (!context.Product.Any())
        {

          context.Product.AddRange(
            new Product
            {
              sku = "BUNDLE-NERF-10046490",
              name = "10 Nerf© Elite Jolt",
              description = "+ 4 OFFERTS",
              price = 64.90M,
              msrp = 94.90M,
              inventory = 45,
              image = "nerf1.jpg",
              hot = true,
            },
            new Product
            {
              sku = "BUNDLE-NERF-04025190",
              name = "4 Nerf© Elite Disruptor",
              description = "+ 2 OFFERTS",
              price = 51.90M,
              msrp = 79.90M,
              inventory = 120,
              image = "nerf2.jpg",
              hot = false,
            },
            new Product
            {
              sku = "BUNDLE-NERF-01124490",
              name = "1 Nerf© Green Moustigre",
              description = "+ 12 OFFERTS",
              price = 44.90M,
              msrp = 59.90M,
              inventory = 12,
              image = "nerf4.jpg",
              hot = true,
            },
            new Product
            {
              sku = "BUNDLE-NERF-01003990",
              name = "1 Nerf© Elite Rapid Strike",
              description = "",
              price = 39.90M,
              msrp = 59.90M,
              inventory = 50,
              image = "nerf3.jpg",
              hot = false,
            }
          );
        }
        context.SaveChanges();
      }

    }
  }
}