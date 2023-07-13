public class Pet
{
    protected string name;
    protected int age;

    public string Name { get; set; }
    public int Age { get; set; }

    public virtual void Eat()
    {
        // Implementation for eating behavior
    }

    public virtual void Play()
    {
        // Implementation for playing behavior
    }

    public virtual void Sleep()
    {
        // Implementation for sleeping behavior
    }
}
