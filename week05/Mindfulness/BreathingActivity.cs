using System;

public class BreathingActivity : Activity
{
    private string[] _boxFramesIn = {
        "□",
        "▢",
        "▣",
        "■"
    };

    private string[] _boxFramesOut = {
        "■",
        "▣", 
        "▢",
        "□"
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
            Console.Write("\nBreathe in...");
            ShowBreathingAnimation(_boxFramesIn, 5);
            Console.Write("\nBreathe out...");
            ShowBreathingAnimation(_boxFramesOut, 5);
            Console.WriteLine();
        }

        DisplayEndingMessage();
    }

    private void ShowBreathingAnimation(string[] frames, int seconds)
    {
        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;
        
        while (DateTime.Now < endTime)
        {
            Console.Write("\r");
            Console.Write($"{frames[frameIndex]} {(int)(endTime - DateTime.Now).TotalSeconds + 1}");
            Thread.Sleep(250);
            frameIndex = (frameIndex + 1) % frames.Length;
        }
    }
} 