using System;

namespace Lab8Arrays
{
    class Program
    {
        static string[] Students = {"Link", "Ryne", "Male Corrin", "DoomGuy", "Geralt", "The Emperor of Mankind", "Chuck Norris", "Ganondorf", "Princess Zelda", "Female Corrin"};
        static string[] FavoriteWeapon= { "The Master Sword", "A Pair of Daggers", "the Yato", "A Shotgun", "A set of Steel and Silver Swords", "The Legiones Astartes", "a Roundhouse Kick", "a Sword", "a Bow", "the Yato" };
        static string[] HomeWorld = { "Hyrule", "The First", "Valla", "????", "The Witcher World", "Holy Terra", "Earth", "Hyrule", "Hyrule", "Valla" };
        static string[] BestFriend = { "Princess Zelda", "Thancred", "Beruka", "Ammuntion", "Triss Merigold", "????", "God", "N/A", "Link", "Silas" };
        static string[] MortalEnemy = { "Ganondorf", "The Light", "Anankanos", "Hell", "The Wild Hunt", "Horus", "no one living", "Link", "Ganondorf", "Anankanos" };
        static int userIndex;
        static void Main(string[] args)
        {
            bool keepTrawling = true;
            
            Console.WriteLine("Welcome to the Inter-Dimensional C# GC Coding Bootcamp!");
            while (keepTrawling)
            {
                userIndex = ValidateRange($"Who would you like to know about? (1,{Students.Length})", 0, Students.Length);
                if (userIndex == -1)
                {
                    Console.WriteLine("===Students===");
                    ListOutArray(Students);
                    Console.WriteLine("");
                    Console.WriteLine("===Weapons===");
                    ListOutArray(FavoriteWeapon);
                    Console.WriteLine("");
                    Console.WriteLine("===Home Worlds===");
                    ListOutArray(HomeWorld); 
                    Console.WriteLine("");
                    Console.WriteLine("===Best Friends===");
                    ListOutArray(BestFriend);
                    Console.WriteLine("");
                    Console.WriteLine("===Mortal Enemies===");
                    ListOutArray(MortalEnemy);
                    Console.WriteLine("");

                    continue;
                }
                Console.WriteLine($"Student number {userIndex} is {Students[userIndex - 1]}!");
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
            string userInput = GetUserInput("What would you like to know about them? 1. Favorite Weapon \n 2. Homeworld \n 3. Best Friend \n 4. Mortal Enemy").ToLower();
            switch (userInput)
            {
                case ("1"):
                    Console.WriteLine($"{Students[userIndex-1]}'s favorite weapon is {FavoriteWeapon[userIndex - 1]}!");
                    break;
                case ("2"):
                    Console.WriteLine($"{Students[userIndex - 1]}'s home world is {HomeWorld[userIndex - 1]}!");
                    break;
                case ("3"):
                    Console.WriteLine($"{Students[userIndex - 1]}'s best friend is {BestFriend[userIndex - 1]}!");
                    break;
                case ("4"):
                    Console.WriteLine($"{Students[userIndex - 1]}'s mortal enemy is {MortalEnemy[userIndex - 1]}!");
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