using System;

/*
The Eternal Quest Program is a gamified goal tracking system that demonstrates object-oriented programming principles through inheritance, polymorphism, encapsulation, and abstraction. It manages three goal types: Simple Goals, Eternal Goals, and Checklist Goals. The program exceeds core requirements by implementing a level system where players earn unique titles every 1000 points (from "Novice Quester" to "Transcendent Being"), features level-up celebrations with emoji announcements, provides an enhanced user interface with better navigation and readability, and includes comprehensive error handling for a more engaging and polished user experience.Retry   "Novice Quester" to "Transcendent Being" for high-level players
 */

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Eternal Quest Program!");
        Console.WriteLine("Track your goals and earn points on your eternal journey!");
        Console.WriteLine();
        
        GoalManager goalManager = new GoalManager();
        goalManager.Start();
    }
}