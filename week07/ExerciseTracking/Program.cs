using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        // Create one of each activity type
        activities.Add(new Running(new DateTime(2025, 2, 20), 30, 3.0));  // 30 min run, 3 miles
        activities.Add(new Cycling(new DateTime(2025, 2, 20), 45, 15.0)); // 45 min cycling at 15 mph
        activities.Add(new Swimming(new DateTime(2025, 2, 20), 40, 20));  // 40 min swimming, 20 laps

        // Display summary for each activity
        Console.WriteLine("Exercise Tracking Summary:");
        Console.WriteLine("------------------------");
        
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}