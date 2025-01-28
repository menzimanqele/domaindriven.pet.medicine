using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Interfaces;

namespace Wpm.Management.Api.Application;

public class SetWeightCommandHandler(ManagementDbContext dbContext, IBreedService breedService) : ICommandHandler<SetWeightCommand>
{
    public async Task Handler(SetWeightCommand command)
    {
        var pet = await dbContext.Pets.FindAsync(command.id);
        pet.SetWeight(command.Weight, breedService);
        dbContext.SaveChangesAsync();
    }
}