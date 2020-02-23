using System;

namespace _2_21_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesWon = 0;
            int gamesLost = 0;

            string userInput = GetMenuChoice();
            while (userInput != "3")
            {
                Route(userInput, ref gamesWon, ref gamesLost);
                userInput = GetMenuChoice();
            }

            Goodbye(gamesWon, gamesLost);
        }

        public static string GetMenuChoice()
        {
            DisplayMenu();
            string userInput = Console.ReadLine();

            while (!ValidMenuChoice(userInput))
            {
                Console.WriteLine("Invalid menu choice.  Please Enter a Valid Menu Choice");
                Console.WriteLine("Press any key to continue....");
                Console.ReadKey();

                DisplayMenu();
                userInput = Console.ReadLine();
            }

            return userInput;
        }

        public static void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("1:   Play Snowman");
            Console.WriteLine("2:   See Scoreboard");
            Console.WriteLine("3:   Exit Game");
        }

        public static Boolean ValidMenuChoice(string userInput)
        {
            if(userInput == "1" || userInput == "2" || userInput == "3")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void Route(string userInput, ref int gamesWon, ref int gamesLost)
        {
            if(userInput == "1")
            {
                SnowMan(ref gamesWon, ref gamesLost);
            }
            else
            {
                if (userInput == "2")
                {
                    ScoreBoard(gamesWon, gamesLost);
                }
            }

        }

        public static void SnowMan(ref int gamesWon, ref int gamesLost)
        {
            Console.Clear();
            string word = GetRandomWord();
            char[] displayWord = SetDisplayWord(word);
            int missed = 0;
            string guessed = "No Letters Guessed Yet";

            while (KeepGoing(displayWord, missed))
            {
                ShowBoard(displayWord, missed, guessed);
                Console.WriteLine();
                char pickedLetter = Console.ReadLine().ToUpper()[0];
                CheckChoice(displayWord, word, ref missed, ref guessed, pickedLetter);
            }

            if (missed == 7)
            {
                Console.WriteLine("Sorry you lost");
                gamesLost++;
            }
            else
            {
                Console.WriteLine("You Won!");
                gamesWon++;
            }
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey();

        }

        public static void CheckChoice(char[] displayWord, string word, ref int missed, 
            ref string guessed, char pickedLetter)
        {
            Boolean badGuess = true;
            for(int i = 0; i < word.Length; i++)
            {
                if(word[i] == pickedLetter)
                {
                    displayWord[i] = pickedLetter;
                    badGuess = false;
                }
            }

            if(badGuess)
            {
                Console.WriteLine("Letter not found... press a key to continue.");
                Console.Clear();
                missed++;
                if(guessed == "No Letters Guessed Yet")
                {
                    guessed = "" + pickedLetter;
                }
                else
                {
                    Console.Clear();
                    guessed += pickedLetter;
                }
            }
            else
            {
                if(guessed == "No Letters Guessed Yet")
                {
                    guessed = "" + pickedLetter;
                }
                else
                {
                    Console.Clear();
                    guessed += pickedLetter;
                }
            }
        }

        public static Boolean KeepGoing(char[] displayWord, int missed)
        {
            if(missed == 7)
            {
                return false;
            }
            for(int i = 0; i < displayWord.Length; i++)
            {
                 if(displayWord[i] == '_')
                 {
                    return true;
                 }
            }
            return false;
        }

        public static void ShowBoard(char[] displayWord, int missed, string guessed)
        {
            Console.WriteLine("Word to guess: ");
            for (int i = 0; i < displayWord.Length; i++)
            {
                Console.Write(displayWord[i]);
            }

            Console.WriteLine();
            Console.WriteLine("Letters Guessed => " + guessed);

            Console.WriteLine("Currently missed " + missed);

        }

        public static char[] SetDisplayWord(string word)
        {
            char[] displayWord = new char[word.Length];
            for(int i = 0; i < word.Length; i++)
            {
                if (word[i] == ' ')
                {
                    displayWord[i] = ' ';
                }
                else
                {
                    displayWord[i] = '_';
                }
                
            }
            return displayWord;
        }
        public static string GetRandomWord()
        {
            string[] wordList =
            { 
                "RAMMER JAMMER", 
                "BIG AL", 
                "TOUCHDOWN ALABAMA", 
                "WORK HARD PLAY HARD", 
                "SECOND AND TWENTY SIX"
            };

            Random randomGenerator = new Random();
            return wordList[randomGenerator.Next(0, 4)];
        }
        public static void ScoreBoard(int gamesWon, int gamesLost)
        {
            Console.Clear();
            Console.WriteLine("You have won " + gamesWon + " games");
            Console.WriteLine("You have lost " + gamesLost + " games");
            Console.WriteLine("Press any key to continue....");
            Console.ReadKey();
        }

        public static void Goodbye(int gamesWon, int gamesLost)
        {
            Console.Clear();
            Console.WriteLine("Thank you for playing... \n" +
                "Press any key for one final look at the scoreboard" +
                " before you go");
            Console.ReadKey();
            ScoreBoard(gamesWon, gamesLost);

        }
    }
}
