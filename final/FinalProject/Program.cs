class Program
{
    static void Main(string[] args)
    {
        // Create instances of Pet subclasses
        Dog dog = new Dog();
        Cat cat = new Cat();
        Fish fish = new Fish();
        Hamster hamster = new Hamster();

        // Set properties
        dog.Name = "Buddy";
        cat.Name = "Whiskers";
        fish.Name = "Nemo";
        hamster.Name = "Nibbles";

        // Invoke specific methods
        dog.Bark();
        cat.Meow();
        fish.Swim();

        // Create PetStore instance
        PetStore petStore = new PetStore();

        // Add pets to the store
        petStore.AddPet(dog);
        petStore.AddPet(cat);
        petStore.AddPet(fish);
        petStore.AddPet(hamster);

        // Display available pets in the store
        petStore.DisplayAvailablePets();

        // Create Veterinary instance
        Veterinary veterinary = new Veterinary();

        // Create Customer instance
        Customer customer = new Customer();
        customer.Name = "John";

        // Interact with pets
        customer.InteractWithPet(dog);
        customer.InteractWithPet(cat);
        customer.InteractWithPet(fish);
        customer.InteractWithPet(hamster);

        // Take pets to the veterinary clinic
        customer.TakePetToVeterinary(dog, veterinary);
        customer.TakePetToVeterinary(cat, veterinary);
        customer.TakePetToVeterinary(fish, veterinary);
        customer.TakePetToVeterinary(hamster, veterinary);
    }
}
