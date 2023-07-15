public abstract class Pet : IPet
{
    protected string _name;
    protected int _age;

    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Eat()
    {
        Console.WriteLine($"{_name} is eating.");
    }

    public virtual void Play()
    {
        Console.WriteLine($"{_name} is playing.");
    }

    public virtual void Sleep()
    {
        Console.WriteLine($"{_name} is sleeping.");
    }
}
