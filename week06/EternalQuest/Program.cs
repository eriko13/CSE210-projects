// Exceeds requirements: a goal tracking system with a leveling mechanic.
// Users earn points for completing goals and automatically level up every 100 points.
// The level system provides additional motivation and a sense of progression.


using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}