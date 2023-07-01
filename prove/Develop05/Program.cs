using System;
using System.Collections.Generic;
using System.IO;

abstract class Goal
{
    private string name;
    private int value;

    public string Name { get { return name; } }
    public int Value { get { return value; } }

    public Goal(string name, int value)
    {
        this.name = name;
        this.value = value;
    }

    public virtual void DisplayStatus()
    {
        Console.WriteLine($"Goal: {name} | Value: {value}");
    }

    public abstract void CompleteGoal();

    public abstract void RecordEvent();

    public virtual string Serialize()
    {
        return $"{GetType().Name},{name},{value}";
    }

    public virtual void Deserialize(string data)
    {
        string[] parts = data.Split(',');
        if (parts.Length >= 3)
        {
            name = parts[1];
            value = int.Parse(parts[2]);
        }
    }
}

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
}

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

    public override void DisplayStatus()
    {
        Console.WriteLine($"Goal: {Name} | Value: {Value} | Completed: {CurrentCount}/{RequiredCount}");
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

    public override string Serialize()
    {
        return $"{base.Serialize()},{requiredCount},{currentCount}";
    }

    public override void Deserialize(string data)
    {
        base.Deserialize(data);

        string[] parts = data.Split(',');
        if (parts.Length >= 5)
        {
            requiredCount = int.Parse(parts[3]);
            currentCount = int.Parse(parts[4]);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();

        LoadGoals(goals);

        if (goals.Count == 0)
        {
            CreateDefaultGoals(goals);
        }

        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("===== Eternal Quest Program =====");
            Console.WriteLine("1. View Goals");
            Console.WriteLine("2. Complete Goal");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Create New Goal");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("0. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Console.Clear();
            switch (choice)
            {
                case "1":
                    DisplayGoals(goals);
                    break;
                case "2":
                    CompleteGoal(goals);
                    break;
                case "3":
                    RecordEvent(goals);
                    break;
                case "4":
                    CreateNewGoal(goals);
                    break;
                case "5":
                    SaveGoals(goals);
                    break;
                case "6":
                    LoadGoals(goals);
                    break;
                case "0":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    static void CreateDefaultGoals(List<Goal> goals)
    {
        goals.Add(new SimpleGoal("Run a Marathon", 1000));
        goals.Add(new EternalGoal("Read Scriptures", 100));
        goals.Add(new ChecklistGoal("Attend the Temple", 50, 10));
    }

    static void CreateNewGoal(List<Goal> goals)
    {
        Console.WriteLine("===== Create New Goal =====");
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal value: ");
        int value = int.Parse(Console.ReadLine());
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Enter goal type: ");
        string type = Console.ReadLine();

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, value));
                break;
            case "2":
                goals.Add(new EternalGoal(name, value));
                break;
            case "3":
                Console.Write("Enter required count: ");
                int requiredCount = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, value, requiredCount));
                break;
            default:
                Console.WriteLine("Invalid goal type. New goal creation failed.");
                break;
        }

        Console.WriteLine("New goal created successfully.");
    }

    static void DisplayGoals(List<Goal> goals)
    {
        Console.WriteLine("===== Goals =====");
        if (goals.Count == 0)
        {
            Console.WriteLine("No goals found.");
        }
        else
        {
            foreach (Goal goal in goals)
            {
                goal.DisplayStatus();
            }
        }
    }

    static void CompleteGoal(List<Goal> goals)
    {
        Console.WriteLine("===== Complete Goal =====");
        Console.Write("Enter the index of the goal to complete: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.CompleteGoal();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    static void RecordEvent(List<Goal> goals)
    {
        Console.WriteLine("===== Record Event =====");
        Console.Write("Enter the index of the goal to record event: ");
        int index = int.Parse(Console.ReadLine());

        if (index >= 0 && index < goals.Count)
        {
            Goal goal = goals[index];
            goal.RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    static void SaveGoals(List<Goal> goals)
    {
        Console.WriteLine("===== Save Goals =====");
        Console.Write("Enter the file name to save goals: ");
        string fileName = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (Goal goal in goals)
            {
                writer.WriteLine(goal.Serialize());
            }
        }

        Console.WriteLine("Goals saved successfully.");
    }

    static void LoadGoals(List<Goal> goals)
    {
        Console.WriteLine("===== Load Goals =====");
        Console.Write("Enter the file name to load goals: ");
        string fileName = Console.ReadLine();

        if (File.Exists(fileName))
        {
            goals.Clear();

            using (StreamReader reader = new StreamReader(fileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 1)
                    {
                        string goalType = parts[0];
                        Goal goal;

                        switch (goalType)
                        {
                            case nameof(SimpleGoal):
                                goal = new SimpleGoal("", 0);
                                break;
                            case nameof(EternalGoal):
                                goal = new EternalGoal("", 0);
                                break;
                            case nameof(ChecklistGoal):
                                goal = new ChecklistGoal("", 0, 0);
                                break;
                            default:
                                Console.WriteLine($"Invalid goal type '{goalType}'. Skipping the goal.");
                                continue;
                        }

                        goal.Deserialize(line);
                        goals.Add(goal);
                    }
                }
            }

            Console.WriteLine("Goals loaded successfully.");
        }
        else
        {
            Console.WriteLine("Goals file not found. Loading failed.");
        }
    }
}
