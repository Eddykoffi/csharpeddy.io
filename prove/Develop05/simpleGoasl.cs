using System;

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
        Console.WriteLine($"Recorded event for Simple Goal: {Name}");
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine("Type: Simple Goal");
    }
}
