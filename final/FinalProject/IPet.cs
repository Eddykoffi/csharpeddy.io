public interface IPet
{
    string Name { get; set; }
    int Age { get; set; }

    void Eat();
    void Play();
    void Sleep();
}
