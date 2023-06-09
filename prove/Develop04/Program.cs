using System;
using System.Collections.Generic;
using System.Threading;

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
            Thread.Sleep(1000);
        }
        Console.WriteLine();
    }
}

// Derived class for the breathing activity
public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Start()
    {
        Console.WriteLine("Breathing Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
        Console.WriteLine("Start breathing...");
        Thread.Sleep(2000);
    }

    public override void End()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Thread.Sleep(3000);
    }
}

// Derived class for the reflection activity
public class ReflectionActivity : Activity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void Start()
    {
        Console.WriteLine("Reflection Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
        Console.WriteLine("Start reflecting...");
        Thread.Sleep(2000);
        Random random = new Random();

        for (int i = 0; i < Duration; i++)
        {
            string prompt = prompts[random.Next(prompts.Count)];
            Console.WriteLine(prompt);
            Thread.Sleep(2000);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                ShowAnimation(2);
            }
        }
    }

    public override void End()
    {
        Console.WriteLine("Well done!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Thread.Sleep(3000);
    }
}

// Derived class for the listing activity
public class ListingActivity : Activity
{
    private List<string> items = new List<string>
    {
        "Read a book",
        "Take a walk",
        "Write in a journal",
        "Listen to music",
        "Do a puzzle",
        "Call a friend",
        "Try a new recipe",
        "Watch a movie",
        "Do some exercise",
        "Meditate"
    };

    public ListingActivity() : base("Listing", "This activity will help you come up with ideas for things to do when you need a break. It can be a fun way to discover new hobbies or activities.")
    {
    }

    public override void Start()
    {
        Console.WriteLine("Listing Activity");
        Console.WriteLine(Description);
        Console.Write("Enter duration in seconds: ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000);
        Console.WriteLine("Start listing...");
        Thread.Sleep(2000);
        Random random = new Random();

        for (int i = 0; i < Duration; i++)
        {
            string item = items[random.Next(items.Count)];
            Console.WriteLine(item);
            ShowAnimation(2);
        }
    }

    public override void End()
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed the {Name} activity for {Duration} seconds.");
        Thread.Sleep(3000);
    }
}

// Main program
public class Program
{
    public static void Main()
    {
        while (true)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1. Breathing");
            Console.WriteLine("2. Reflection");
            Console.WriteLine("3. Listing");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice (1-4): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Activity breathingActivity = new BreathingActivity();
                    PerformActivity(breathingActivity);
                    break;

                case "2":
                    Activity reflectionActivity = new ReflectionActivity();
                    PerformActivity(reflectionActivity);
                    break;

                case "3":
                    Activity listingActivity = new ListingActivity();
                    PerformActivity(listingActivity);
                    break;

                case "4":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public static void PerformActivity(Activity activity)
    {
        activity.Start();
        activity.End();
    }
}
