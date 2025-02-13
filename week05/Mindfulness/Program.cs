using System;

/*
Mindfulness Program - Enhanced Features

This program exceeds the base requirements in the following ways:

1. Enhanced Animation Features:
   - Added a dancing stick figure animation that changes colors
   - Implemented growing/shrinking box for breathing exercises

2. Activity Tracking and Logging:
   - Tracks number of times each activity is performed per session
   
*/

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflection activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;
                case "2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;
                case "3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;
                case "4":
                    Console.WriteLine("\nThank you for using the Mindfulness Program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}