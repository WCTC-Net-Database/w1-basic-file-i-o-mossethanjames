using System;
using System.IO;

class Programgit
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1. Display Characters");
        Console.WriteLine("2. Add Character");
        Console.WriteLine("3. Level Up Character");

        var menuOption = Console.ReadLine();

        if (menuOption == "1")
        {
            DisplayCharacters();
        }
        else if (menuOption == "2")
        {
            AddCharacter();
        }
        else if (menuOption == "3")
        {
            LevelUpCharacter();
        }
    }

    static void DisplayCharacters()
    {
        var lines = File.ReadAllLines("input.csv");

        for (int i = 1; i < lines.Length; i++)
        {
            var cols = lines[i].Split(',');

            string name = cols[0];
            string job = cols[1];
            string level = cols[2];
            string hitPoints = cols[3];
            string equipment = cols[4];

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Job: {job}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Hit Points: {hitPoints}");
            Console.WriteLine($"Equipment: {equipment}");
            Console.WriteLine("--------------------");
        }
    }

    static void AddCharacter()
    {
        Console.WriteLine("Enter character name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter character job:");
        var job = Console.ReadLine();

        Console.WriteLine("Enter character level:");
        var level = Console.ReadLine();

        Console.WriteLine("Enter character hit points:");
        var hitPoints = Console.ReadLine();

        Console.WriteLine("Enter character equipment:");
        var equipment = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter("input.csv", true))
        {
            writer.WriteLine($"{name},{job},{level},{hitPoints},{equipment}");
        }
    }

    static void LevelUpCharacter()
    {
        var lines = File.ReadAllLines("input.csv");

        Console.WriteLine("Enter the name of the character to level up:");
        var nameToLevelUp = Console.ReadLine();

        for (int i = 1; i < lines.Length; i++)
        {
            var cols = lines[i].Split(',');

            if (cols[0].Equals(nameToLevelUp, StringComparison.OrdinalIgnoreCase))
            {
                int currentLevel = int.Parse(cols[2]);
                cols[2] = (currentLevel + 1).ToString();
                lines[i] = string.Join(",", cols);
                break;
            }
        }

        File.WriteAllLines("input.csv", lines);
    }
}
