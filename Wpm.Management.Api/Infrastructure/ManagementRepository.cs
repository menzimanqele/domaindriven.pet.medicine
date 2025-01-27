using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Interfaces;

namespace Wpm.Management.Api.Infrastructure;

public class ManagementRepository : IManagementRepository
{
    private readonly ManagementDbContext _context;

    public ManagementRepository(ManagementDbContext context)
    {
        _context = context;
    }
    public Pet? GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Pet> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Add(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void Update(Pet pet)
    {
        throw new NotImplementedException();
    }

    public void Delete(Pet pet)
    {
        throw new NotImplementedException();
    }
}