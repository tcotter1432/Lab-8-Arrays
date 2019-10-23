using System;

namespace Lab8Arrays
{
    class Program
    {
        static string[] students = {"Link", "Ryne", "Male Corrin", "DoomGuy", "Geralt", "The Emperor of Mankind", "Chuck Norris", "Ganondorf", "Princess Zelda", "Female Corrin"};
        static string[] favoriteWeapon= { "The Master Sword", "A Pair of Daggers", "the Yato", "A Shotgun", "A set of Steel and Silver Swords", "The Legiones Astartes", "a Roundhouse Kick", "a Sword", "a Bow of Light", "the Yato" };
        static string[] homeWorld = { "Hyrule", "The First", "Valla", "????", "The Witcher World", "Holy Terra", "Earth", "Hyrule", "Hyrule", "Valla" };
        static string[] bestFriend = { "Princess Zelda", "Thancred", "Beruka", "Ammuntion", "Triss Merigold", "????", "God", "N/A", "Link", "Silas" };
        static string[] mortalEnemy = { "Ganondorf", "The Light", "Anankanos", "Hell", "The Wild Hunt", "Horus", "no one living", "Link", "Ganondorf", "Anankanos" };
        static int userIndex;
        static void Main(string[] args)
        {
            bool keepTrawling = true;
            
            Console.WriteLine("Welcome to the Inter-Dimensional C# GC Coding Bootcamp!");
            while (keepTrawling)
            {
                userIndex = ValidateRange($"Who would you like to know about? (1,{students.Length})", 0, students.Length);
                if (userIndex == -1)
                {
                    Console.WriteLine("===Students===");
                    ListOutArray(students);
                    Console.WriteLine("");
                    Console.WriteLine("===Weapons===");
                    ListOutArray(favoriteWeapon);
                    Console.WriteLine("");
                    Console.WriteLine("===Home Worlds===");
                    ListOutArray(homeWorld); 
                    Console.WriteLine("");
                    Console.WriteLine("===Best Friends===");
                    ListOutArray(bestFriend);
                    Console.WriteLine("");
                    Console.WriteLine("===Mortal Enemies===");
                    ListOutArray(mortalEnemy);
                    Console.WriteLine("");

                    continue;
                }
                Console.WriteLine($"Student number {userIndex} is {students[userIndex - 1]}!");
                //Console.WriteLine("What would you like to know about them? (FavoriteWeapon, Homeworld, BestFriend)");
                CheckInfoInput();

                keepTrawling = CheckContinue();
            }

        }

        public static int ValidateRange(string message, int min, int max)
        {
            int number = ParseString(message);
            if (number == -1)
            {
                return number;
            }
            else if (number > min && number <= max)
            {
                return number;
            }
            else
            {
                return ValidateRange("Invalid input, try again...", min, max);
            }
        }

        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void ListOutArray(string[] theArray)
        {
            for (int i = 0; i < theArray.Length; i++)
            {
                Console.Write(theArray[i]+ " ");
            }
        }

        public static int ParseString(string message)
        {
            try
            {
                string input = GetUserInput(message);
                int number = int.Parse(input);
                return number;
            }
            catch
            {
                return ParseString(message);
            }
        }
        public static void CheckInfoInput()
        {
            string userInput = GetUserInput("What would you like to know about them? \n 1. Favorite Weapon \n 2. Homeworld \n 3. Best Friend \n 4. Mortal Enemy \n 5. Different Student").ToLower();
            switch (userInput)
            {
                case ("1"):
                    Console.WriteLine($"{students[userIndex-1]}'s favorite weapon is {favoriteWeapon[userIndex - 1]}!");
                    CheckInfoInput();
                    break;
                case ("2"):
                    Console.WriteLine($"{students[userIndex - 1]}'s home world is {homeWorld[userIndex - 1]}!");
                    CheckInfoInput();
                    break;
                case ("3"):
                    Console.WriteLine($"{students[userIndex - 1]}'s best friend is {bestFriend[userIndex - 1]}!");
                    CheckInfoInput();
                    break;
                case ("4"):
                    Console.WriteLine($"{students[userIndex - 1]}'s mortal enemy is {mortalEnemy[userIndex - 1]}!");
                    CheckInfoInput();
                    break;
                case ("5"):
                    break;
                default:
                    Console.WriteLine("Invalid input...");
                    CheckInfoInput();
                    break;
            }
        }
        public static bool CheckContinue()
        {
            Console.Write("Would you like to keep going? (y/n) ");
            string input = Console.ReadLine().ToLower();
            if (input == "y")
            {
                return true;
            }
            else if (input == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input!");
                return CheckContinue();
            }
        }
    }
}