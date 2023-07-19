using System;
using System.Collections.Generic;
using System.IO;

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
        // Add some default goals here if needed
    }

    static void CreateNewGoal(List<Goal> goals)
    {
        // Implementation to create a new goal as shown earlier
    }

    static void DisplayGoals(List<Goal> goals)
    {
        // Implementation to display goals as shown earlier
    }

    static void CompleteGoal(List<Goal> goals)
    {
        // Implementation to complete a goal as shown earlier
    }

    static void RecordEvent(List<Goal> goals)
    {
        // Implementation to record an event as shown earlier
    }

    static void SaveGoals(List<Goal> goals)
    {
        // Implementation to save goals as shown earlier
    }

    static void LoadGoals(List<Goal> goals)
    {
        // Implementation to load goals as shown earlier
    }
}
