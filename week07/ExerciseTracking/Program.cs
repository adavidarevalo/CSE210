using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Exercise Tracking Program");
        Console.WriteLine("========================");
        Console.WriteLine();

        // Create a list to hold all activities
        List<Activity> activities = new List<Activity>();

        // Create activities of each type
        // Running: 30 minutes, 3.0 miles distance
        Running runningActivity = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        activities.Add(runningActivity);

        // Cycling: 45 minutes, 15 mph speed
        Cycling cyclingActivity = new Cycling(new DateTime(2022, 11, 4), 45, 15.0);
        activities.Add(cyclingActivity);

        // Swimming: 25 minutes, 40 laps
        Swimming swimmingActivity = new Swimming(new DateTime(2022, 11, 5), 25, 40);
        activities.Add(swimmingActivity);

        // Display summary for each activity using polymorphism
        Console.WriteLine("Activity Summaries:");
        Console.WriteLine("------------------");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }

        Console.WriteLine();
        Console.WriteLine("Detailed Information:");
        Console.WriteLine("--------------------");

        // Show detailed information for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine($"Activity Type: {activity.GetType().Name}");
            Console.WriteLine($"Date: {activity.GetDate():dd MMM yyyy}");
            Console.WriteLine($"Duration: {activity.GetMinutes()} minutes");
            Console.WriteLine($"Distance: {activity.GetDistance():F2} miles");
            Console.WriteLine($"Speed: {activity.GetSpeed():F2} mph");
            Console.WriteLine($"Pace: {activity.GetPace():F2} min per mile");
            Console.WriteLine();
        }
    }
}