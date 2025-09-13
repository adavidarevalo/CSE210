using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("This program helps you record daily events and thoughts.");

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    SearchEntries(journal);
                    break;
                case "6":
                    ShowJournalSummary(journal);
                    break;
                case "7":
                    Console.WriteLine("Thank you for using the Journal Program!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-7.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void DisplayMenu()
    {
        Console.Clear();
        Console.WriteLine("=== JOURNAL PROGRAM MENU ===");
        Console.WriteLine("1. Write a new entry");
        Console.WriteLine("2. Display the journal");
        Console.WriteLine("3. Save the journal to a file");
        Console.WriteLine("4. Load the journal from a file");
        Console.WriteLine("5. Search entries");
        Console.WriteLine("6. Show journal summary");
        Console.WriteLine("7. Quit");
        Console.WriteLine("=============================");
        Console.Write("Please select an option (1-7): ");
    }

    static void WriteNewEntry(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== WRITE NEW ENTRY ===");
        
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"Prompt: {prompt}");
        Console.WriteLine();
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(response))
        {
            string date = DateTime.Now.ToShortDateString();
            Entry newEntry = new Entry(prompt, response, date);
            journal.AddEntry(newEntry);
            Console.WriteLine("\nEntry saved successfully!");
        }
        else
        {
            Console.WriteLine("\nEntry not saved - response was empty.");
        }
    }

    static void SaveJournal(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== SAVE JOURNAL ===");
        
        if (journal.EntryCount == 0)
        {
            Console.WriteLine("No entries to save.");
            return;
        }

        Console.Write("Enter filename to save to: ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            journal.SaveToFile(filename);
        }
        else
        {
            Console.WriteLine("Invalid filename.");
        }
    }

    static void LoadJournal(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== LOAD JOURNAL ===");
        Console.WriteLine("WARNING: This will replace all current entries!");
        Console.Write("Enter filename to load from: ");
        string filename = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(filename))
        {
            Console.Write("Are you sure you want to replace current entries? (y/n): ");
            string confirm = Console.ReadLine().ToLower();
            
            if (confirm == "y" || confirm == "yes")
            {
                journal.LoadFromFile(filename);
            }
            else
            {
                Console.WriteLine("Load cancelled.");
            }
        }
        else
        {
            Console.WriteLine("Invalid filename.");
        }
    }

    static void SearchEntries(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== SEARCH ENTRIES ===");
        
        if (journal.EntryCount == 0)
        {
            Console.WriteLine("No entries to search.");
            return;
        }

        Console.Write("Enter keyword to search for: ");
        string keyword = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            var results = journal.SearchEntries(keyword);
            
            if (results.Count > 0)
            {
                Console.WriteLine($"\nFound {results.Count} entries containing '{keyword}':");
                Console.WriteLine("=====================================");
                
                foreach (Entry entry in results)
                {
                    Console.WriteLine(entry.GetDisplayString());
                    Console.WriteLine("---");
                }
            }
            else
            {
                Console.WriteLine($"No entries found containing '{keyword}'.");
            }
        }
        else
        {
            Console.WriteLine("Invalid search term.");
        }
    }

    static void ShowJournalSummary(Journal journal)
    {
        Console.Clear();
        Console.WriteLine("=== JOURNAL SUMMARY ===");
        Console.WriteLine(journal.GetSummary());
    }
}
