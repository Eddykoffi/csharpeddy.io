class Program
{
    static void Main(string[] args)
    {
        PetStore petStore = new PetStore();
        Veterinary veterinary = new Veterinary();

        IPet dog = new Dog { Name = "Buddy", Age = 3 };
        IPet cat = new Cat { Name = "Whiskers", Age = 5 };
        IPet fish = new Fish { Name = "Nemo", Age = 1 };
        IPet hamster = new Hamster { Name = "Nibbles", Age = 2 };

        petStore.AddPet(dog);
        petStore.AddPet(cat);
        petStore.AddPet(fish);
        petStore.AddPet(hamster);

        Customer customer = new Customer { Name = "John" };

        foreach (IPet pet in petStore.GetAvailablePets())
        {
            customer.InteractWithPet(pet);
            customer.TakePetToVeterinary(pet, veterinary);
        }
    }
}
