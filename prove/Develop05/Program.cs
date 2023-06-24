using System;
using System.Collections.Generic;
using System.IO;

public abstract class Goal
{
    public string Name { get; set; }
    public int Value { get; set; }
    public bool Completed { get; set; }

    public virtual void MarkComplete()
    {
        Completed = true;
    }

    public virtual string DisplayStatus()
    {
        return Completed ? "[X]" : "[ ]";
    }
}

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, int value)
    {
        Name = name;
        Value = value;
    }
}

public class ChecklistGoal : Goal
{
    public int TargetCount { get; set; }
    public int CurrentCount { get; set; }
    public int BonusValue { get; set; }

    public ChecklistGoal(string name, int value, int targetCount, int bonusValue)
    {
        Name = name;
        Value = value;
        TargetCount = targetCount;
        BonusValue = bonusValue;
    }

    public override void MarkComplete()
    {
        CurrentCount++;
        if (CurrentCount == TargetCount)
            Completed = true;
    }

    public override string DisplayStatus()
    {
        return $"Completed {CurrentCount}/{TargetCount} times";
    }
}

public class QuestTracker
{
    public List<Goal> Goals { get; set; }
    public int Score { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }

    public QuestTracker()
    {
        Goals = new List<Goal>();
        Score = 0;
        Level = 1;
        Experience = 0;
    }

    public void AddGoal(Goal goal)
    {
        Goals.Add(goal);
    }

    public void RecordEvent(string goalName)
    {
        foreach (var goal in Goals)
        {
            if (goal.Name == goalName)
            {
                goal.MarkComplete();
                Score += goal.Value;

                if (goal is ChecklistGoal checklistGoal && checklistGoal.Completed)
                {
                    Score += checklistGoal.BonusValue;
                    Experience += checklistGoal.BonusValue;

                    if (Experience >= Level * 1000)
                    {
                        Level++;
                        Experience = 0;
                    }
                }

                break;
            }
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Quest Goals:");
        foreach (var goal in Goals)
        {
            Console.WriteLine($"{goal.DisplayStatus()} - {goal.Name}");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Current Score: {Score}");
        Console.WriteLine($"Level: {Level}");
        Console.WriteLine($"Experience: {Experience}/{Level * 1000}");
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var goal in Goals)
            {
                writer.WriteLine($"{goal.GetType().Name},{goal.Name},{goal.Value},{goal.Completed}");

                if (goal is ChecklistGoal checklistGoal)
                {
                    writer.WriteLine($"{checklistGoal.TargetCount},{checklistGoal.CurrentCount},{checklistGoal.BonusValue}");
                }
            }

            writer.WriteLine(Score);
            writer.WriteLine(Level);
            writer.WriteLine(Experience);
        }
    }

    public void LoadGoals(string filename)
    {
        Goals.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');

                string goalType = parts[0];
                string goalName = parts[1];
                int goalValue = int.Parse(parts[2]);
                bool goalCompleted = bool.Parse(parts[3]);

                Goal goal;

                switch (goalType)
                {
                    case nameof(SimpleGoal):
                        goal = new SimpleGoal(goalName, goalValue);
                        break;
                    case nameof(EternalGoal):
                        goal = new EternalGoal(goalName, goalValue);
                        break;
                    case nameof(ChecklistGoal):
                        int targetCount = int.Parse(parts[4]);
                        int currentCount = int.Parse(parts[5]);
                        int bonusValue = int.Parse(parts[6]);
                        goal = new ChecklistGoal(goalName, goalValue, targetCount, bonusValue);
                        ((ChecklistGoal)goal).CurrentCount = currentCount;
                        break;
                    default:
                        throw new InvalidOperationException($"Invalid goal type: {goalType}");
                }

                goal.Completed = goalCompleted;
                Goals.Add(goal);
            }

            Score = int.Parse(reader.ReadLine());
            Level = int.Parse(reader.ReadLine());
            Experience = int.Parse(reader.ReadLine());
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        QuestTracker tracker = new QuestTracker();

        // Create and add goals
        Goal goal1 = new SimpleGoal("Complete Quest 1", 10);
        Goal goal2 = new EternalGoal("Explore Dungeon", 5);
        Goal goal3 = new ChecklistGoal("Collect 5 Gems", 2, 5, 10);

        tracker.AddGoal(goal1);
        tracker.AddGoal(goal2);
        tracker.AddGoal(goal3);

        // Record events
        tracker.RecordEvent("Complete Quest 1");
        tracker.RecordEvent("Explore Dungeon");
        tracker.RecordEvent("Collect 5 Gems");
        tracker.RecordEvent("Collect 5 Gems");
        tracker.RecordEvent("Collect 5 Gems");
        tracker.RecordEvent("Collect 5 Gems");
        tracker.RecordEvent("Collect 5 Gems");

        // Display goals and score
        tracker.DisplayGoals();
        Console.WriteLine();
        tracker.DisplayScore();

        // Save goals
        tracker.SaveGoals("goals.txt");

        // Reset tracker and load goals
        tracker = new QuestTracker();
        tracker.LoadGoals("goals.txt");

        // Display loaded goals and score
        Console.WriteLine("\nLoaded Goals:");
        tracker.DisplayGoals();
        Console.WriteLine();
        tracker.DisplayScore();
    }
}
