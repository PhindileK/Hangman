using System;

namespace Hangman
{
    class Program
    {
        // Method to allow user to play again. 
        static void Main(string[] args)
        {
            // use boolean expression and while loop. while the loop is true (user inserts "y"), repeat the game method
            bool playAgain = true;

            while (playAgain)
            {
                PlayHangman();

                Console.WriteLine("Do you want to play again? (y/n)");
                string playAgainInput = Console.ReadLine();

                // or operator allows user to input small y or big Y
                playAgain = (playAgainInput == "y" || playAgainInput == "Y");
            }

            Console.WriteLine("Thank you for playing Hangman!");
        }

        // method for the game. We call this method above when the user inputs a "Y"
        static void PlayHangman()
        {
            // Introductory Display messages 
            Console.WriteLine("Let's play Hangman!");
            Console.WriteLine("Reveal the word by guessing one letter at a time. You only have 7 attempts!");
            Console.WriteLine("Hint : Colours");

            // List of words in the game 
            string[] listwords = { "yellow", "brown", "pink", "orange", "black" };

            // Pick a random word from the list
            string guessWord = listwords[new Random().Next(0, listwords.Length)];
            char[] guess = new char[guessWord.Length];

            // Number of attemps user is given
            int attempts = 7;

            // Go through the chosen word and insert "_" to every letter (counter = 1)
            for (int p = 0; p < guessWord.Length; p++)
                guess[p] = '_';
            
            // this while loop is executed so long as the user still has attempts
            while (attempts > 0)
            {
                Console.WriteLine("Please enter your guess");
                char userInput = char.Parse(Console.ReadLine());
                bool correctGuess = false;

                // go through the chosen word (counter = 1) and see if any letter matches with the user input, if so add it to the word
                for (int j = 0; j < guessWord.Length; j++)
                {
                    if (userInput == guessWord[j])
                    {
                        guess[j] = userInput;
                        correctGuess = true;
                    }
                }

                Console.WriteLine(guess);

                // checks if the output "guess" matches the original word 
                if (correctGuess)
                {
                    if (new string(guess) == guessWord)
                    {
                        Console.WriteLine("Congratulations! You guessed the word correctly.");
                        break;
                    }
                }
                else
                {
                    attempts--;
                    Console.WriteLine($"Wrong letter! Attempts remaining: {attempts}");
                }
            }
            // ends game if attempts are 0
            if (attempts == 0)
            {
                Console.WriteLine("You ran out of attempts. The word was: " + guessWord);
            }
        }
    }
}
