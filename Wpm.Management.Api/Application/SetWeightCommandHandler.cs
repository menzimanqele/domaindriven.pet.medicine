using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Interfaces;

namespace Wpm.Management.Api.Application;

public class SetWeightCommandHandler : ICommandHandler<SetWeightCommand>
{
    private readonly ManagementDbContext _dbContext;
    private readonly IBreedService _breedService;

    public SetWeightCommandHandler(ManagementDbContext dbContext, IBreedService breedService)
    {
        _dbContext = dbContext;
        _breedService = breedService;
        DomainEvents.PetWeightUpdated.Subscribe((domainEvent) =>
        {
            Console.Write("Pet weight updated");
        });
    }
    public async Task Handler(SetWeightCommand command)
    {
        var pet = await _dbContext.Pets.FindAsync(command.id);
        pet?.SetWeight(command.Weight, _breedService);
        await _dbContext.SaveChangesAsync();
    }
}