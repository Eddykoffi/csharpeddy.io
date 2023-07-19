using System;

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
