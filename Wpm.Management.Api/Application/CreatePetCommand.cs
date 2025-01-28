using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Api.Application;

public record CreatePetCommand(Guid id, string name, int age, string color, SexOfPet SexOfPet, Guid breedId)
{
    
}