using System;

class Program
{
    static void Main(string[] args)
    {

        Reference reference = new Reference("John", 3, 16);
        Scripture scripture = new Scripture(reference, "For God so loved the world, that he gave his only Son, that whoever believes in him should not perish but have eternal life.");
        string response = "";

           
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\nPress enter to continue or type 'quit' to finish.");

        while(!scripture.IsCompletelyHidden() && response != "quit")
        {
            response = Console.ReadLine();

            Console.Clear();

            if(response == ""){
                scripture.HideRandomWords(3);
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish.");
            }
        }
    }
}