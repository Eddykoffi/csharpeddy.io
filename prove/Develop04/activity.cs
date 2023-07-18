using System;

// Base class for all activities
public abstract class Activity
{
    private string name;
    private string description;
    private int duration;

    public string Name
    {
        get { return name; }
        protected set { name = value; }
    }

    public string Description
    {
        get { return description; }
        protected set { description = value; }
    }

    public int Duration
    {
        get { return duration; }
        protected set { duration = value; }
    }

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
