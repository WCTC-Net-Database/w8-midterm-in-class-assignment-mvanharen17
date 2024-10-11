using System;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Xml.Linq;
namespace CharacterConsole
{ 
    public class CharacterReader
    {
        string[] lines;

        public void Display()
        {
            lines = File.ReadAllLines("input.csv");
            Console.WriteLine("\n=== Characters ===");
            // Skip the header row
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                int commaIndex = lines[i].IndexOf(',');

                if (line.StartsWith('"'))
                {
                    string name = lines[i].Substring(0, commaIndex);
                    var firstQuotePos = lines[i].IndexOf('"');
                    lines[i] = lines[i].Substring(firstQuotePos + 1);
                    var lastQuotePos = lines[i].IndexOf('"');
                    name = lines[i].Substring(firstQuotePos, lastQuotePos - firstQuotePos);
                    commaIndex = lines[i].IndexOf('"') + 1;
                    Console.WriteLine($"\nName: {name}");

                    lines[i] = lines[i].Substring(name.Length + 2);
                    commaIndex = lines[i].IndexOf(",");
                    var characterClass = lines[i].Substring(0, commaIndex);
                    Console.WriteLine($"Class: {characterClass}");

                    lines[i] = lines[i].Substring(characterClass.Length + 1);
                    var splits = lines[i].Split(",");
                    var level = splits[0];
                    var HP = splits[1];
                    string[] equipment = splits[2].Split("|");

                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"HP: {HP}");
                    Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");
                }
                else
                {
                    var splits = lines[i].Split(",");
                    string name = splits[0];
                    string characterClass = splits[1];
                    var level = splits[2];
                    var HP = splits[3];
                    string[] equipment = splits[4].Split("|");

                    Console.WriteLine($"\nName: {name}");
                    Console.WriteLine($"Class: {characterClass}");
                    Console.WriteLine($"Level: {level}");
                    Console.WriteLine($"HP: {HP}");
                    Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");
                }
            }
        }
        public void Find()
        {
            lines = File.ReadAllLines("input.csv");
            Console.Write("Enter the name of the character: ");
            string findCharacter = Console.ReadLine();
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                int commaIndex = lines[i].IndexOf(',');

                if (line.StartsWith('"'))
                {
                    var name = lines[i].Substring(0, commaIndex);
                    var firstQuotePos = lines[i].IndexOf('"');
                    lines[i] = lines[i].Substring(firstQuotePos + 1);
                    var lastQuotePos = lines[i].IndexOf('"');
                    name = lines[i].Substring(firstQuotePos, lastQuotePos - firstQuotePos);
                    commaIndex = lines[i].IndexOf('"') + 1;

                    lines[i] = lines[i].Substring(name.Length + 2);
                    commaIndex = lines[i].IndexOf(",");
                    var characterClass = lines[i].Substring(0, commaIndex);

                    lines[i] = lines[i].Substring(characterClass.Length + 1);
                    var splits = lines[i].Split(",");
                    var level = splits[0];
                    var HP = splits[1];
                    string[] equipment = splits[2].Split("|");

                    var query = line.Where(name => findCharacter.Equals(name)).FirstOrDefault();
                    
                    
                    foreach (var l in query)
                    {
                        Console.WriteLine($"\nName: {name}");
                        Console.WriteLine($"Class: {characterClass}");
                        Console.WriteLine($"Level: {level}");
                        Console.WriteLine($"HP: {HP}");
                        Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");

                    }

                }
                else
                {
                    var splits = lines[i].Split(",");
                    string name = splits[0];
                    var characterClass = splits[1];
                    var level = splits[2];
                    var HP = splits[3];
                    string[] equipment = splits[4].Split("|");

                    var query = lines.Where(name => name.Equals(findCharacter));

                    Console.WriteLine($"{string.Join(", ", query)}");

                    //foreach (var l in query)
                    //{
                    //    Console.WriteLine($"\nName: {name}");
                    //    Console.WriteLine($"Class: {characterClass}");
                    //    Console.WriteLine($"Level: {level}");
                    //    Console.WriteLine($"HP: {HP}");
                    //    Console.WriteLine($"Equipment: {string.Join(", ", equipment)}");

                    //}
                }
            }
        }
    }
}