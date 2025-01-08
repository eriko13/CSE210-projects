using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        PlayGame();
    }

    static void PlayGame()
    {
      Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 100);

        int? guess = null;

        int attempts = 0;

        while (guess != magicNumber)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            attempts++;

            if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }

        }

        Console.WriteLine("\nYou guessed it!");
        Console.WriteLine($"It took you {attempts} attempts.");
        Console.WriteLine("\nDo you want to play again? (y/n)");
        string playAgain = Console.ReadLine();

        if (playAgain == "y")
        {
            PlayGame();
        }
    }
}