using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {   
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int input;
        List<int> numbers = new List<int>();
        int sum = 0;
        int max = int.MinValue;
        int smallestPositive = int.MaxValue;

        while (true) {
            Console.Write("Enter a number: ");
            input = int.Parse(Console.ReadLine());
            if (input == 0) {
                break;
            }
            numbers.Add(input);
            sum += input;
            if (input > max) {
                max = input;
            }
            if (input > 0 && input < smallestPositive) {
                smallestPositive = input;
            }
        }

        double avg = sum / numbers.Count;

        Console.WriteLine($"The sum is {sum}");
        Console.WriteLine($"The average is {avg}");
        Console.WriteLine($"The largest number is {max}");
        Console.WriteLine($"The smallest positive number is {smallestPositive}");

        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}