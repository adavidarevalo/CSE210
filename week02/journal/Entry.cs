using System;

public class Entry
{
    private string _prompt;
    private string _response;
    private string _date;

    public Entry(string prompt, string response, string date)
    {
        _prompt = prompt;
        _response = response;
        _date = date;
    }

    public string Prompt => _prompt;

    public string Response => _response;

    public string Date => _date;

    public string GetDisplayString()
    {
        return $"Date: {_date}\nPrompt: {_prompt}\nEntry: {_response}\n";
    }

    public string GetFileString()
    {
        return $"{_date}|{_prompt}|{_response}";
    }

    public static Entry FromFileString(string fileString)
    {
        string[] parts = fileString.Split('|');
        if (parts.Length == 3)
        {
            return new Entry(parts[1], parts[2], parts[0]);
        }
        throw new ArgumentException("Invalid file string format");
    }
}
