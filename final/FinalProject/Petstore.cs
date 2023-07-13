using System.Collections.Generic;

public class PetStore
{
    protected List<Pet> pets;

    public PetStore()
    {
        pets = new List<Pet>();
    }

    public void AddPet(Pet pet)
    {
        pets.Add(pet);
    }

    public void DisplayAvailablePets()
    {
        // Implementation for displaying available pets in the store
    }
}
