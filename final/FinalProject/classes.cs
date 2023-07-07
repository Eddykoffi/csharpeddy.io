using System;
using System.Collections.Generic;

public abstract class Pet
{
    public string Name { get; set; }
    public int Age { get; set; }

    public abstract void Eat();
    public abstract void Play();
    public abstract void Sleep();
}

public class Dog : Pet
{
    public override void Eat()
    {
        Console.WriteLine("Dog is eating.");
    }

    public override void Play()
    {
        Console.WriteLine("Dog is playing.");
    }

    public override void Sleep()
    {
        Console.WriteLine("Dog is sleeping.");
    }
}

public class Cat : Pet
{
    public override void Eat()
    {
        Console.WriteLine("Cat is eating.");
    }

    public override void Play()
    {
        Console.WriteLine("Cat is playing.");
    }

    public override void Sleep()
    {
        Console.WriteLine("Cat is sleeping.");
    }
}

public class Fish : Pet
{
    public override void Eat()
    {
        Console.WriteLine("Fish is eating.");
    }

    public override void Play()
    {
        Console.WriteLine("Fish is swimming.");
    }

    public override void Sleep()
    {
        Console.WriteLine("Fish is sleeping.");
    }
}

public class Hamster : Pet
{
    public override void Eat()
    {
        Console.WriteLine("Hamster is eating.");
    }

    public override void Play()
    {
        Console.WriteLine("Hamster is playing.");
    }

    public override void Sleep()
    {
        Console.WriteLine("Hamster is sleeping.");
    }
}

public class PetStore
{
    private List<Pet> pets;

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
        Console.WriteLine("Available pets in the pet store:");
        foreach (Pet pet in pets)
        {
            Console.WriteLine($"- {pet.GetType().Name} named {pet.Name} ({pet.Age} years old)");
        }
    }
}

public class Customer
{
    public string Name { get; set; }

    public void InteractWithPet(Pet pet)
    {
        Console.WriteLine($"{Name} is interacting with {pet.Name}:");
        pet.Eat();
        pet.Play();
        pet.Sleep();
        Console.WriteLine();
    }

    public void TakePetToVeterinary(Pet pet, Veterinary veterinary)
    {
        Console.WriteLine($"{Name} is taking {pet.Name} to the veterinary clinic:");
        veterinary.Checkup(pet);
        veterinary.Vaccinate(pet);
        veterinary.TreatInjury(pet);
        Console.WriteLine();
    }
}

public class Veterinary
{
    public void Checkup(Pet pet)
    {
        Console.WriteLine($"Performing a checkup on {pet.Name}.");
    }

    public void Vaccinate(Pet pet)
    {
        Console.WriteLine($"Administering vaccinations to {pet.Name}.");
    }

    public void TreatInjury(Pet pet)
    {
        Console.WriteLine($"Treating {pet.Name}'s injury or ailment.");
    }
}

public class Program
{
    public static void Main()
    {
        PetStore petStore = new PetStore();

        Dog dog = new Dog { Name = "Buddy", Age = 3 };
        Cat cat = new Cat { Name = "Whiskers", Age = 5 };
        Fish fish = new Fish { Name = "Nemo", Age = 1 };
        Hamster hamster = new Hamster { Name = "Nibbles", Age = 2 };

        petStore.AddPet(dog);
        petStore.AddPet(cat);
        petStore.AddPet(fish);
        petStore.AddPet(hamster);

        Veterinary veterinary = new Veterinary();

        Customer customer1 = new Customer { Name = "Alice" };
        Customer customer2 = new Customer { Name = "Bob" };

        petStore.DisplayAvailablePets();

        Console.WriteLine();

        customer1.InteractWithPet(dog);
        customer1.InteractWithPet(cat);
        customer2.InteractWithPet(fish);
        customer2.InteractWithPet(hamster);

        Console.WriteLine();

        customer1.TakePetToVeterinary(dog, veterinary);
        customer1.TakePetToVeterinary(cat, veterinary);
        customer2.TakePetToVeterinary(fish, veterinary);
        customer2.TakePetToVeterinary(hamster, veterinary);
    }
}
