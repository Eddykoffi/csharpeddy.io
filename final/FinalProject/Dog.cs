public class Dog : Pet
{
    public void Bark()
    {
        Console.WriteLine($"{_name} is barking.");
    }

    public override void Play()
    {
        Console.WriteLine($"{_name} is playing fetch.");
    }
}
