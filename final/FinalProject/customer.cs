using System;

public class Customer
{
    protected string _name;

    public string Name { get; set; }

    public void InteractWithPet(IPet pet)
    {
        Console.WriteLine($"{_name} is interacting with {pet.Name}.");
        pet.Play();
    }

    public void TakePetToVeterinary(IPet pet, Veterinary vet)
    {
        Console.WriteLine($"{_name} is taking {pet.Name} to the veterinary clinic.");
        vet.Checkup(pet);
        vet.Vaccinate(pet);
        vet.TreatInjury(pet);
    }
}
