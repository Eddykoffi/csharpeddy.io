using System;

class EternalGoal : Goal
{
    public EternalGoal(string name, int value) : base(name, value)
    {
    }

    public override void CompleteGoal()
    {
        Console.WriteLine("Cannot complete an Eternal Goal.");
    }

    public override void RecordEvent()
    {
        Console.WriteLine($"Recorded event for Eternal Goal: {Name}");
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine("Type: Eternal Goal");
    }
}
