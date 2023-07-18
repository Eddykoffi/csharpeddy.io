class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value) : base(name, value)
    {
    }

    public override void CompleteGoal()
    {
        Console.WriteLine($"Completed Simple Goal: {Name}");
    }

    public override void RecordEvent()
    {
        Console.WriteLine("Cannot record event for a Simple Goal.");
    }
}
