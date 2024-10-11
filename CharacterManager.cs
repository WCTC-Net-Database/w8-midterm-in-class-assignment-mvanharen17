using System;
using System.IO;
using System.Reflection.Emit;
using System.Xml.Linq;
namespace CharacterConsole
{ 
    public class CharacterManager
    {
        string[] lines;
        public void Run()
        {
            Console.WriteLine("Welcome to Character Management");

            lines = File.ReadAllLines("input.csv");

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Display Characters");
                Console.WriteLine("2. Find Character");
                Console .WriteLine("3. Add Character");
                Console.WriteLine("4. Level Up Character");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayCharacters();
                        break;
                    case "2":
                        FindCharacter();
                        break;
                    case "3":
                        AddCharacter();
                        break;
                    case "4":
                        LevelUpCharacter();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        void DisplayCharacters()
        {
            CharacterReader characterReader = new CharacterReader();
            characterReader.Display();
        }

        void FindCharacter()
        {
            CharacterReader characterReader = new CharacterReader();
            characterReader.Find();
        }

        public void AddCharacter()
        {
            CharacterWriter characterWriter = new CharacterWriter();
            characterWriter.Add();
        }

        public void LevelUpCharacter()
        {
            CharacterWriter characterWriter = new CharacterWriter();
            characterWriter.LevelUp();
        }
    }
}