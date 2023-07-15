public class Hamster : Pet
{
    public override void Play()
    {
        Console.WriteLine($"{_name} is running on a wheel.");
    }
}
