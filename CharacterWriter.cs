using System;
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace CharacterConsole
{
    public class CharacterWriter
    {
        string[] lines;

        public void Add()
        {
            Console.Write("\n=== Add a Character ===\n");

            Console.Write("Enter your character's name: ");
            string charName = Console.ReadLine();

            Console.Write("Enter your character's class: ");
            string charClass = Console.ReadLine();

            Console.Write("Enter your character's level: ");
            int level = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's HP: ");
            int hp = int.Parse(Console.ReadLine());

            Console.Write("Enter your character's equipment (separate items with a '|'): ");
            string[] equipment = Console.ReadLine().Split('|');

            StreamWriter sw = new StreamWriter("input.csv", true);
            sw.WriteLine($"{charName},{charClass},{level},{hp},{string.Join("|", equipment)}");
            sw.Flush();
            sw.Close();

            Console.WriteLine($"Welcome, {charName} the {charClass}! You are level {level} with {hp} HP, and your equipment includes: {string.Join(", ", equipment)}.\n");
        }

        public void LevelUp()
        {
            Console.Write("Enter the name of the character to level up: ");
            string nameToLevelUp = Console.ReadLine();
            lines = File.ReadAllLines("input.csv");

            // Loop through characters to find the one to level up
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                // TODO: Check if the name matches the one to level up
                // Do not worry about case sensitivity at this point
                if (line.Contains(nameToLevelUp))
                {
                    int commaIndex = lines[i].IndexOf(',');

                    var splits = lines[i].Split(",");
                    var name = splits[0];
                    var characterClass = splits[1];
                    var level = splits[2];
                    var HP = splits[3];
                    string[] equipment = splits[4].Split("|");

                    int j = int.Parse(level);
                    var newlevel = Convert.ToString(j + 1);


                    lines[i] = ($"{name},{characterClass},{level},{HP},{string.Join("|", equipment)}");

                    StreamWriter sw = new StreamWriter("input.csv", true);
                    sw.WriteLine($"\n{name},{characterClass},{newlevel},{HP},{string.Join("|", equipment)}");
                    sw.Flush();
                    sw.Close();

                    Console.WriteLine($"{name} is now Level {newlevel}");
                    break;
                }
            }
        }
    }
}
