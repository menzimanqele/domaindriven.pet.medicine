using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api.Application;

public class ManagementApplicationService(IBreedService breedService, ManagementDbContext dbContext)
{
    public async Task Handle(CreatePetCommand command)
    {
        var breedId = new BreedId(command.breedId,breedService);
        var newPet = new Pet(command.id,
                    command.name,
                    command.age,
                    command.color,
                    command.SexOfPet,
                     breedId);

        dbContext.Pets.AddAsync(newPet);
        dbContext.SaveChangesAsync();
    }
    
    public async Task Handle(SetWeightCommand command)
    {
        var pet = await dbContext.Pets.FindAsync(command.id);
        pet.SetWeight(command.Weight, breedService);
        dbContext.SaveChangesAsync();
    }

}