using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;
using Xunit;

namespace Wpm.Clinic.Domain.Tests;

public class UnitTests
{
    [Fact]
    public void Consultation_Should_Be_Open()
    {
        var consultation = new Consultation(Guid.NewGuid());
        Assert.True(consultation.Status == ConsultationStatus.Open);
    }
    
    [Fact]
    public void Consultation_Should_Be_Not_Have_Ended_Timestamp()
    {
        var consultation = new Consultation(Guid.NewGuid());
        Assert.Null(consultation.EndedAt);
    }

    [Fact]
    public void Consultation_Should_Be_Not_End_Missing_Data()
    {
        var consultation = new Consultation(Guid.NewGuid());
        Assert.Throws<InvalidOperationException>(consultation.End);
    }
    
    
    [Fact]
    public void Consultation_should_end_with_complete_data()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.True(c.Status == ConsultationStatus.Closed);
    }

    [Fact]
    public void Consultation_should_not_allow_weight_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetWeight(19.2m));
    }

    [Fact]
    public void Consultation_should_not_allow_diagnosis_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetDiagnosis("New diagnosis"));
    }

    [Fact]
    public void Consultation_should_not_allow_treatment_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(18.5m);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetTreatment("New treatment"));
    }

    [Fact]
    public void Consultation_should_administer_drug()
    {
        var drugId = new DrugId(Guid.NewGuid());
        var c = new Consultation(Guid.NewGuid());
        c.AdministerDrug(drugId, new Dose(1,UnitOfMeasure.tablet));
        Assert.True(c.AdministeredDrugs.Count == 1);
        Assert.True(c.AdministeredDrugs.First().DrugId == drugId);
    }

    [Fact]
    public void Consultation_should_register_vitalsigns()
    {
        var c = new Consultation(Guid.NewGuid());
        IEnumerable<VitalSigns> vitalSigns = [new VitalSigns(DateTime.UtcNow, 38.8m, 100, 120)];
        c.RegisterVitalSigns(vitalSigns);
        Assert.True(c.VitalSignReadings.Count == 1);
        Assert.True(c.VitalSignReadings.First() == vitalSigns.First());
    }
}