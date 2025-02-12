using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities;

public class DrugAdministration : Entity
{
    public DrugId DrugId { get; init; }
    public Dose Dose { get; init; }

    public DrugAdministration(DrugId drugId, Dose dose)
    {
        DrugId = drugId;
        Dose = dose;
        Id = Guid.NewGuid();
    }
}