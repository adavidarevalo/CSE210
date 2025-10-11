using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;
        while (choice != 6)
        {
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");

            string input = Console.ReadLine();
            if (int.TryParse(input, out choice))
            {
                switch (choice)
                {
                    case 1:
                        CreateGoal();
                        break;
                    case 2:
                        ListGoalDetails();
                        break;
                    case 3:
                        SaveGoals();
                        break;
                    case 4:
                        LoadGoals();
                        break;
                    case 5:
                        RecordEvent();
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
            
            if (choice != 6)
            {
                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        
        int level = CalculateLevel();
        string title = GetPlayerTitle(level);
        Console.WriteLine($"Level: {level} - {title}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDisplayString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string input = Console.ReadLine();
        if (int.TryParse(input, out int choice))
        {
            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();

            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();

            Console.Write("What is the amount of points associated with this goal? ");
            string pointsInput = Console.ReadLine();
            if (!int.TryParse(pointsInput, out int points))
            {
                Console.WriteLine("Invalid points value.");
                return;
            }

            switch (choice)
            {
                case 1:
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case 2:
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case 3:
                    Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                    string targetInput = Console.ReadLine();
                    if (!int.TryParse(targetInput, out int target))
                    {
                        Console.WriteLine("Invalid target value.");
                        return;
                    }

                    Console.Write("What is the bonus for accomplishing it that many times? ");
                    string bonusInput = Console.ReadLine();
                    if (!int.TryParse(bonusInput, out int bonus))
                    {
                        Console.WriteLine("Invalid bonus value.");
                        return;
                    }

                    _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input.");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet. Create a goal first!");
            return;
        }

        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        string input = Console.ReadLine();
        
        if (int.TryParse(input, out int choice) && choice > 0 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            int pointsEarned = selectedGoal.RecordEvent();
            
            if (pointsEarned > 0)
            {
                _score += pointsEarned;
                Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_score} points.");
                
                CheckLevelUp();
            }
            else
            {
                Console.WriteLine("This goal has already been completed!");
            }
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string dataDir = "data";
        if (!Directory.Exists(dataDir))
        {
            Directory.CreateDirectory(dataDir);
        }
        
        string filePath = Path.Combine(dataDir, filename);

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filePath))
            {
                outputFile.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine($"Goals saved successfully to {filePath}!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        string dataDir = "data";
        string filePath = Path.Combine(dataDir, filename);

        try
        {
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                _goals.Clear();

                if (lines.Length > 0)
                {
                    _score = int.Parse(lines[0]);

                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] parts = lines[i].Split(':');
                        string goalType = parts[0];
                        string[] goalData = parts[1].Split(',');

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                string name = goalData[0];
                                string description = goalData[1];
                                int points = int.Parse(goalData[2]);
                                bool isComplete = bool.Parse(goalData[3]);
                                _goals.Add(new SimpleGoal(name, description, points, isComplete));
                                break;
                            case "EternalGoal":
                                name = goalData[0];
                                description = goalData[1];
                                points = int.Parse(goalData[2]);
                                _goals.Add(new EternalGoal(name, description, points));
                                break;
                            case "ChecklistGoal":
                                name = goalData[0];
                                description = goalData[1];
                                points = int.Parse(goalData[2]);
                                int bonus = int.Parse(goalData[3]);
                                int target = int.Parse(goalData[4]);
                                int amountCompleted = int.Parse(goalData[5]);
                                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                                break;
                        }
                    }
                }
                Console.WriteLine($"Goals loaded successfully from {filePath}!");
            }
            else
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    private int CalculateLevel()
    {
        return (_score / 1000) + 1;
    }

    private string GetPlayerTitle(int level)
    {
        string[] titles = {
            "Novice Quester",
            "Dedicated Seeker", 
            "Faithful Warrior",
            "Noble Champion",
            "Heroic Crusader",
            "Legendary Paladin",
            "Divine Sentinel",
            "Eternal Guardian",
            "Celestial Master",
            "Immortal Legend"
        };

        if (level <= titles.Length)
        {
            return titles[level - 1];
        }
        else
        {
            return "Transcendent Being";
        }
    }

    private void CheckLevelUp()
    {
        int currentLevel = CalculateLevel();
        int previousLevel = ((_score - 100) / 1000) + 1;
        
        if (currentLevel > previousLevel)
        {
            Console.WriteLine();
            Console.WriteLine("🎉 LEVEL UP! 🎉");
            Console.WriteLine($"You have reached Level {currentLevel}: {GetPlayerTitle(currentLevel)}!");
            Console.WriteLine();
        }
    }
}