using System;
using System.Collections.Generic;
using System.Threading;

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
        Console.WriteLine(Name + " Activity");
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
