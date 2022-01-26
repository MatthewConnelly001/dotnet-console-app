using System;


// Namespace
namespace NumberGenerator
{
    // Main Class
    internal class Program
    {
        // Entry Point Method
        static void Main(string[] args)
        {
            ShowAppInfo();
            GreetUser();

            // Game loop.
            while(true)
            {
                // Set number to guess.
                int correctNumber = new Random().Next(1, 10);

                // Starting guessing loop.
                Console.WriteLine("Guess a number between 1 and 10");
                while (true)
                {
                    Console.Write("What is your guess? ");
                    string input = Console.ReadLine();

                    // Checking for a bad input.
                    if (!int.TryParse(input, out int guess))
                    {
                        OutputBadInput(input);
                        continue;
                    }

                    // Checking whether number is above or below correct number.
                    if (guess < correctNumber)
                        WriteColorMessage(ConsoleColor.Red, $"INCORRECT!!! The number is above {guess}! Try again!");
                    else if (guess > correctNumber)
                        WriteColorMessage(ConsoleColor.Red, $"INCORRECT!!! The number is below {guess}! Try again!");
                    else
                    {
                        WriteColorMessage(ConsoleColor.Yellow, $"CORRECT!!! The number is {guess}!");
                        break;
                    }
                }

                // Ask to play again.
                Console.Write("Play again? [Y] ");
                if (Console.ReadLine().ToUpper() != "Y")
                    break;

            }
            // App is done.
            Console.WriteLine("Welp that's all folks! See you next time!");
        }


        static void OutputBadInput(string input)
        {
            WriteColorMessage(ConsoleColor.Magenta, $"{input} is not a number! Try again!");
        }

        // Shows the information of the app.
        static void ShowAppInfo()
        {
            // app vars
            string appName = "Number Guesser";
            string appVersion = "1.0.0";
            string appAuthor = "Matthew Connelly";

            // Write app version in green text.
            WriteColorMessage(ConsoleColor.Green, $"{appName}: Version {appVersion} by {appAuthor}");
        }

        // Ask for user's name and greet them.
        static void GreetUser()
        {
            Console.Write("What is your name? ");
            string userName = Console.ReadLine();
            Console.WriteLine("Hi {0}! Lets play a game...", userName);
        }

        // Writes a string in a selected color to the console.
        static void WriteColorMessage(ConsoleColor color, string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }


}
