using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _253505_Pavlovich.Persistence.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SaleAdvertisement>().OwnsOne<Car>(t => t.CarInfo);
        modelBuilder.Entity<SaleAdvertisement>().OwnsOne<Salesman>(t => t.SalesmanInfo);
    }

    public DbSet<CarBrand> Brands { get; set; }
    public DbSet<SaleAdvertisement> Advertisements { get; set; }
}
