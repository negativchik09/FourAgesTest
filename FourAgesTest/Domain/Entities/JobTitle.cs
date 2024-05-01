using Microsoft.AspNetCore.Http.HttpResults;

namespace FourAgesTest.Domain.Entities;

public class JobTitle
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }
    
    private JobTitle(Guid id, string name)
    {
        Id = id;
        SetName(name);
    }

    public static JobTitle Create(string name)
    {
        return new JobTitle(Guid.NewGuid(), name);
    }

    public void SetName(string name)
    {
        Name = name; // possible validation addition
    }
}