using System;

public class Journal {
    public List<Entry> _entries = [];

    public void AddEntry(Entry newEntry) {
        Console.WriteLine("Adding entry...");
        Console.WriteLine(newEntry.Display());
        _entries.Add(newEntry);
    }

    public void DisplayAll() {
        Console.WriteLine("Displaying all entries...");
        foreach (Entry entry in _entries) {
            Console.WriteLine(entry.Display());
        }
    }

    public void SaveToFile(string filename) {
        Console.WriteLine($"Saving to file: {filename}...");
         
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (Entry entry in _entries) {
                writer.WriteLine(entry.ToFormattedString());
            }
        }
    }

    public void LoadFromFile(string filename) {
        Console.WriteLine($"Loading from file: {filename}");
        using (StreamReader reader = new StreamReader(filename)) {
            string line;
            while ((line = reader.ReadLine()) != null) {
                Console.WriteLine(line);

                string[] parts = line.Split('|');
                
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string response = parts[2];

                Entry newEntry = new Entry(date, prompt, response);

                _entries.Add(newEntry);
            }
        }
    }

}