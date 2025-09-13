using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries;
    private List<string> _prompts;

    public Journal()
    {
        _entries = new List<Entry>();
        InitializePrompts();
    }

    public int EntryCount => _entries.Count;

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What made me smile today?",
            "What challenge did I overcome today?",
            "What am I grateful for today?",
            "What did I learn about myself today?",
            "How did I help someone else today?"
        };
    }

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries in journal.");
            return;
        }

        Console.WriteLine("\n=== JOURNAL ENTRIES ===");
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.GetDisplayString());
            Console.WriteLine("---");
        }
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    outputFile.WriteLine(entry.GetFileString());
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} does not exist.");
                return;
            }

            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    Entry entry = Entry.FromFileString(line);
                    _entries.Add(entry);
                }
            }

            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

    public string GetSummary()
    {
        if (_entries.Count == 0)
        {
            return "Journal is empty.";
        }

        return $"Journal contains {_entries.Count} entries.";
    }

    public List<Entry> SearchEntries(string keyword)
    {
        List<Entry> results = new List<Entry>();
        string searchTerm = keyword.ToLower();

        foreach (Entry entry in _entries)
        {
            if (entry.Response.ToLower().Contains(searchTerm) || 
                entry.Prompt.ToLower().Contains(searchTerm))
            {
                results.Add(entry);
            }
        }

        return results;
    }
}
