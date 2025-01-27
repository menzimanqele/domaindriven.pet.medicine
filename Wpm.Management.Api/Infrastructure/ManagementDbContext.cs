using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Infrastructure;

public class ManagementDbContext : DbContext
{
    public ManagementDbContext(DbContextOptions<ManagementDbContext> options)
    :base(options)
    {
        
    }
    
    public DbSet<Pet> Pets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Pet>().HasKey(p=>p.Id);
        modelBuilder.Entity<Pet>().Property(p => p.BreedId)
            .HasConversion(v=>v.Value,v=>BreedId.Create(v));
        modelBuilder.Entity<Pet>().OwnsOne(p => p.Weight);
    }
}

public static class ManagementDbContextExtensions
{
    public static void EnsureDbIsCreated(this IApplicationBuilder applicationBuilder)
    {
        using var scope = applicationBuilder.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ManagementDbContext>();
        context.Database.EnsureCreated();
        context.Database.CloseConnection();
    }
}