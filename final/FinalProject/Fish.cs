public class Fish : Pet
{
    public void Swim()
    {
        Console.WriteLine($"{_name} is swimming.");
    }

    public override void Eat()
    {
        Console.WriteLine($"{_name} is eating fish food.");
    }
}
