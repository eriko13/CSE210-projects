using System;

class Program
{
    static void Main(string[] args)
    {   
        BibleScriptures bibleScriptures = new BibleScriptures();
        Scripture scripture = bibleScriptures.GetRandomScripture();
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
            }else{
                Console.WriteLine("Invalid input. Press enter to continue or type 'quit' to finish.");
            }
        }
    }
}