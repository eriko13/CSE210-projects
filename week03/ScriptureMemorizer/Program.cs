using System;

class Program
{
    static void Main(string[] args)
    {

        Reference reference = new Reference("John", 18, 36, 38);
        Scripture scripture = new Scripture(reference, "Jesus said, 'My kingdom is not of this world. If it were, my servants would fight to prevent my arrest by the Jews. But now my kingdom is from another place.' You are a king, then! said Pilate. Jesus answered, 'You are right in saying I am a king. In fact, for this reason I was born, and for this I came into the world, to testify to the truth. Everyone on the side of truth listens to me.' What is truth? Pilate asked. With this he went out again to the Jews and said, 'I find no basis for a charge against him.'");
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