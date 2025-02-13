using System;

public class BreathingActivity : Activity
{
    private string[] _breatheInFrames = {
        @"
    ┌─────┐
    │     │
    │     │
    │     │
    └─────┘",
        @"
   ┌───────┐
   │       │
   │       │
   │       │
   └───────┘",
        @"
  ┌─────────┐
  │         │
  │         │
  │         │
  └─────────┘",
        @"
 ┌───────────┐
 │           │
 │           │
 │           │
 └───────────┘",
        @"
┌─────────────┐
│             │
│             │
│             │
└─────────────┘"
    };

    private string[] _breatheOutFrames = {
        @"
┌─────────────┐
│             │
│             │
│             │
└─────────────┘",
        @"
 ┌───────────┐
 │           │
 │           │
 │           │
 └───────────┘",
        @"
  ┌─────────┐
  │         │
  │         │
  │         │
  └─────────┘",
        @"
   ┌───────┐
   │       │
   │       │
   │       │
   └───────┘",
        @"
    ┌─────┐
    │     │
    │     │
    │     │
    └─────┘"
    };

    public BreathingActivity() 
        : base("Breathing Activity", 
            "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartingMessage();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            // Breathing in phase
            Console.Clear();
            Console.WriteLine("\nBreathe in...");
            Console.WriteLine();
            ShowBreathingAnimation(_breatheInFrames, 4);
            
            // Breathing out phase
            Console.Clear();
            Console.WriteLine("\nBreathe out...");
            Console.WriteLine();
            ShowBreathingAnimation(_breatheOutFrames, 6);
        }

        DisplayEndingMessage();
    }

    private void ShowBreathingAnimation(string[] frames, int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        double totalDuration = (endTime - DateTime.Now).TotalMilliseconds;
        int frameCount = frames.Length;
        
        for (int i = 0; i < frameCount; i++)
        {
            // Clear everything except the first two lines (breathing instruction)
            Console.SetCursorPosition(0, 2);
            for (int j = 0; j < 10; j++)  // Clear enough lines to cover the previous frame
            {
                Console.WriteLine(new string(' ', Console.WindowWidth));
            }
            
            // Return cursor to start drawing position
            Console.SetCursorPosition(0, 2);
            Console.WriteLine(frames[i]);
            
            // Show countdown at the bottom of the box
            int remainingSeconds = (int)Math.Ceiling((endTime - DateTime.Now).TotalSeconds);
            Console.WriteLine($"\nSeconds remaining: {remainingSeconds}");
            
            // Calculate pause duration to make animation smooth across the total time
            int pauseDuration = (int)(seconds * 1000 / frameCount);
            Thread.Sleep(pauseDuration);
        }
    }
} 