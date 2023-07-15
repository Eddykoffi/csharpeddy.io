public class Cat : Pet
{
    public void Meow()
    {
        Console.WriteLine($"{_name} is meowing.");
    }

    public override void Sleep()
    {
        Console.WriteLine($"{_name} is taking a nap.");
    }
}
