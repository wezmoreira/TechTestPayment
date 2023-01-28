using Microsoft.EntityFrameworkCore;
using Pottencial.Domain.Entities;
using Pottencial.Infra.Context.Mappings;

namespace Pottencial.Infra.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Seller> Sellers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new OrderMap());
        modelBuilder.ApplyConfiguration(new ItemMap());
        modelBuilder.ApplyConfiguration(new SellerMap());
    }
}