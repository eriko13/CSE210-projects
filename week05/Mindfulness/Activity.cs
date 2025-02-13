using System;
using System.Collections.Generic;
using System.IO;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    private static Dictionary<string, int> _sessionLog = new Dictionary<string, int>();
    private string _logFile = "mindfulness_log.txt";

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        
        // Initialize session count if not exists
        if (!_sessionLog.ContainsKey(_name))
        {
            _sessionLog[_name] = 0;
        }
    }

    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.WriteLine($"You have completed this activity {_sessionLog[_name]} times this session.");
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowLoadingAnimation(3);
    }

    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowLoadingAnimation(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowLoadingAnimation(3);
        
        _sessionLog[_name]++;
    }

    protected void ShowLoadingAnimation(int seconds)
    {
        string[] danceFrames = {
            @"    o
    /|\
    / \",

            @"    o
    /|\
    | |",

            @"     o_
    /|
    / \",

            @"   \o/
    |
    / \",

            @"    o_
   /|
   / \",

            @"    o
   \|/
    / \"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int frameIndex = 0;
        ConsoleColor[] colors = { ConsoleColor.Cyan, ConsoleColor.Blue, ConsoleColor.Magenta };
        int colorIndex = 0;

        while (DateTime.Now < endTime)
        {
            Console.Clear();
            Console.ForegroundColor = colors[colorIndex];

            string[] lines = danceFrames[frameIndex].Split('\n');
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }

            Thread.Sleep(200);

            frameIndex = (frameIndex + 1) % danceFrames.Length;
            colorIndex = (colorIndex + 1) % colors.Length;
        }

        Console.ForegroundColor = ConsoleColor.Gray;
        Console.Clear();
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}