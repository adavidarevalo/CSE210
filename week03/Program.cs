using System;

class Program
{
    static void Main()
    {
        var reference = new Reference("Proverbs", 3, 5, 6);
        var text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding.";
        var scripture = new Scripture(reference, text);

        Console.WriteLine("Scripture Memorizer\n");

        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture);
            if (scripture.AllHidden())
            {
                Console.WriteLine("\nAll words hidden. Well done!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide words, or type 'quit' to exit.");
            var userInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(userInput) && userInput.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}
