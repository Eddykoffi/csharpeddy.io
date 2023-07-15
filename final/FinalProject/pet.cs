public abstract class Pet : IPet
{
    protected string _name;
    protected int _age;

    public string Name { get; set; }
    public int Age { get; set; }

    public abstract void Eat();
    public abstract void Play();
    public abstract void Sleep();
}
