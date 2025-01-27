using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Api.Infrastructure;

public class ManagementDbContext : DbContext
{
    public ManagementDbContext(DbContextOptions<ManagementDbContext> options)
    :base(options)
    {
        
    }
    
    public DbSet<Pet> Pets { get; set; }
}