using System;

public class Veterinary
{
    public void Checkup(IPet pet)
    {
        Console.WriteLine($"Performing checkup on {pet.Name}.");
    }

    public void Vaccinate(IPet pet)
    {
        Console.WriteLine($"Administering vaccination to {pet.Name}.");
    }

    public void TreatInjury(IPet pet)
    {
        Console.WriteLine($"Treating injury of {pet.Name}.");
    }
}
