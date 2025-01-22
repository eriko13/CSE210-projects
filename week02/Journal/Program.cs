using System;
// Added [moodLevel] to the Entry class as exceeding the requirements
class Program
{   

    static void Main(string[] args)
    {
        int option = 0;
        Journal _journal = new Journal();
        PromptGenerator _promptGenerator = new PromptGenerator();


        while(option != 5){
            DisplayMenu();
            option = GetOption();
            ProcessOption(option, _journal, _promptGenerator);
        }
    }

    public static void DisplayMenu() {
        Console.WriteLine("1. Add Entry");
        Console.WriteLine("2. Display All Entries");
        Console.WriteLine("3. Save to File");
        Console.WriteLine("4. Load from File");
        Console.WriteLine("5. Exit");
    }

    public static int GetOption() {
        Console.WriteLine("Enter an option: ");
        string input = Console.ReadLine();
        int option = int.Parse(input);
        return option;
    }

    public static void ProcessOption(int option, Journal _journal, PromptGenerator _promptGenerator) {
        switch(option) {
            case 1:
                CreateEntry(_journal, _promptGenerator);
                break;
            case 2:
                DisplayAllJournalEntries(_journal);
                break;
            case 3:
                SaveJournalToFile(_journal);
                break;
            case 4:
                LoadJournalFromFile(_journal);
                break;
            case 5:
                Console.WriteLine("Exiting...");
                break;
            default:
                Console.WriteLine("Invalid option");
                break;
        }
    }

    public static void CreateEntry( Journal _journal, PromptGenerator _promptGenerator) {
        string randomPrompt = _promptGenerator.GetRandomPrompt();
        Console.WriteLine(randomPrompt);
        string response = Console.ReadLine();

        Console.WriteLine("What is your mood level (0=sad ... 10=very happy): ");
        string moodLevelInput = Console.ReadLine();
        int moodLevel = int.Parse(moodLevelInput);

        _journal.AddEntry(
            new Entry(
                DateTime.Now,
                randomPrompt,
                response,
                moodLevel
            )
        );
    }

    public static void DisplayAllJournalEntries(Journal _journal) {
        _journal.DisplayAll();
    }

    public static void SaveJournalToFile(Journal _journal) {
        Console.WriteLine("Enter a filename: ");
        string filename = Console.ReadLine();
        _journal.SaveToFile(filename);
    }

    public static void LoadJournalFromFile(Journal _journal) {
        Console.WriteLine("Enter a filename: ");
        string filename = Console.ReadLine();
        _journal.LoadFromFile(filename);
    }
}