using System;
using System.Collections.Generic;

public class PetStore
{
    protected List<IPet> _pets;

    public PetStore()
    {
        _pets = new List<IPet>();
    }

    public void AddPet(IPet pet)
    {
        _pets.Add(pet);
    }

    public void DisplayAvailablePets()
    {
        Console.WriteLine("Available Pets:");
        foreach (IPet pet in _pets)
        {
            Console.WriteLine($"- {pet.Name}");
        }
    }

    public List<IPet> GetAvailablePets()
    {
        return _pets;
    }
}
