using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentageStr = Console.ReadLine();
        int gradePercentage = int.Parse(gradePercentageStr);

        char letterGrade = 'F';
        char sign = ' ';

        if (gradePercentage >= 90)
        {
            letterGrade = 'A';
        }
        else if (gradePercentage >= 80)
        {
            letterGrade = 'B';
        }
        else if (gradePercentage >= 70)
        {
            letterGrade = 'C';
        }
        else if (gradePercentage >= 60)
        {
            letterGrade = 'D';
        }

        if (gradePercentage % 10 >= 7)
        {
            sign = '+';
        }
        else if (gradePercentage % 10 <= 3)
        {
            sign = '-';
        }

        if (letterGrade == 'F' || gradePercentage >= 97)
        {
            sign = ' ';
        }



        Console.WriteLine($"Your grade is {letterGrade} {sign}");

        if (gradePercentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("Sorry, you failed. Better luck next time!");
        }

    }
}