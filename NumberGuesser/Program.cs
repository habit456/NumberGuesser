using System;

namespace NumberGuesser
{
    // Main class
    class Program
    {
        // Entry point method
        static void Main(string[] args)
        {
            GetAppInfo();
            GreetUser();

            while (true)
            {
                Console.WriteLine("I'm going to think of a number between a minimum number and a maximum number");
                int min = GetMin();
                int max = GetMax();
                int correctNumber = GenerateRandomNumber(min, max);

                int guess = int.MaxValue;

                Console.WriteLine("Guess a number between {0} and {1}", min, max);


                while (guess != correctNumber)
                {
                    string input = Console.ReadLine();

                    if (!int.TryParse(input, out guess))
                    {
                        PrintColorMessage(ConsoleColor.Red, "Not a number. Please try again...");
                        continue;
                    }

                    if (guess != correctNumber)
                    {
                        PrintColorMessage(ConsoleColor.Red, "Wrong number. Please try again...");
                    }

                }

                PrintColorMessage(ConsoleColor.Yellow, "You are correct!");

                // ask to play again
                Console.WriteLine("Play again? [Y/N]");

                string answer = Console.ReadLine().ToUpper();

                if (answer == "N")
                {
                    break;
                }
                else if (answer == "Y")
                {
                    continue;
                }

            }
        }

        private static int GetMin()
        {
            int min;

            while (true)
            {
                Console.Write("Please enter the minimum number: ");
                string minString = Console.ReadLine();
                if (int.TryParse(minString, out min))
                {
                    break;
                }
            }

            return min;
        }

        private static int GetMax()
        {
            int max;

            while (true)
            {
                Console.Write("Please enter the maximum number: ");
                string maxString = Console.ReadLine();
                if (int.TryParse(maxString, out max))
                {
                    break;
                }
            }

            return max;
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            int correctNumber = random.Next(min, max);
            return correctNumber;
        }

        private static void GetAppInfo()
        {
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Joshua Kaplan";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0}: Version {1} by {2}", appName, appVersion, appAuthor);
            Console.ResetColor();
        }


        private static void GreetUser()
        {
            Console.WriteLine("What is your name?");
            string inputName = Console.ReadLine();
            Console.WriteLine("Hello {0}, let's play a game...", inputName);
        }

        private static void PrintColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
