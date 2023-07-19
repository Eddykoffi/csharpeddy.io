using System;

class ChecklistGoal : Goal
{
    private int requiredCount;
    private int currentCount;

    public int RequiredCount { get { return requiredCount; } }
    public int CurrentCount { get { return currentCount; } }

    public ChecklistGoal(string name, int value, int requiredCount) : base(name, value)
    {
        this.requiredCount = requiredCount;
        this.currentCount = 0;
    }

    public override void CompleteGoal()
    {
        if (currentCount >= requiredCount)
        {
            Console.WriteLine($"Cannot complete the Checklist Goal {Name}. It is already completed.");
        }
        else
        {
            Console.WriteLine($"Completed Checklist Goal: {Name}");
            currentCount = requiredCount;
        }
    }

    public override void RecordEvent()
    {
        if (currentCount < requiredCount)
        {
            Console.WriteLine($"Recorded event for Checklist Goal: {Name}");
            currentCount++;
        }
        else
        {
            Console.WriteLine($"Cannot record event for the Checklist Goal {Name}. It is already completed.");
        }
    }

    public override void DisplayStatus()
    {
        base.DisplayStatus();
        Console.WriteLine($"Type: Checklist Goal | Progress: {CurrentCount}/{RequiredCount}");
    }
}
