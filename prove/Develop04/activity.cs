using System;

// Base class for all activities
public abstract class Activity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public abstract void Start();
    public abstract void End();

    protected void ShowAnimation(int seconds)
    {
        for (int i = 0; i < seconds; i++)
        {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}
