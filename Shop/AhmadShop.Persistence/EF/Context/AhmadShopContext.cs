using AhmadShop.Application.ExternalInterfaces.DbConteracts;
using AhmadShop.Domain.Entities;
using AhmadShop.Domain.Entities.Users;
using AhmadShop.Persistence.EF.Configs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistance.EF.Context;

public class AhmadShopContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>, ICHMSDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Product> Products { get; set; }

    public IQueryable<Customer> GetCustomers() => Set<Customer>().AsQueryable();
    public IQueryable<Order> GetOrders() => Set<Order>().AsQueryable();
    public IQueryable<Payment> GetPayments() => Set<Payment>().AsQueryable();
    public IQueryable<Product> GetProducts() => Set<Product>().AsQueryable();

    public AhmadShopContext(DbContextOptions<AhmadShopContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Ensure Identity configurations are applied
        base.OnModelCreating(modelBuilder);

        // Apply other configurations for the shop entities
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);
    }

    // Async method to save changes to the database
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
