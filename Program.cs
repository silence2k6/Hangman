namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool restartGame = true;

            while (restartGame == true)
            {               
                List<string> wordList = new List<string>() { "RAKETE", "PROGRAMMING", "CODING", "HONULULU", "MENTORING" };
                List<char> userInputStorage = new List<char>();
              
                Random randomGenerator = new Random();
                int choosenWord = randomGenerator.Next(wordList.Count);
                string randomWord = wordList[choosenWord];

                Console.WriteLine($"the random Word is {randomWord}");

                int length = randomWord.Length;

                Console.WriteLine($"the word has {length} Letters");

                char[] unknownWord = new char[length];

                for (int pos = 0; pos < length; pos++)
                {
                    unknownWord[pos] = '_';
                    Console.Write(unknownWord[pos]);
                }

                int remainingTries = 1;

                string guessedWord = "";

                while (guessedWord != randomWord)
                {
                    Console.Write($"\nTry to find the word (you still have {remainingTries} tries):\t");

                    bool validChar;
                    bool validLetter;
                    char userInput;

                    validChar = Char.TryParse(Console.ReadLine().ToUpper(), out userInput);
                    validLetter = Char.IsLetter(userInput);

                    if (validChar == false || validLetter == false)
                    {
                        Console.WriteLine("Please enter an single alphabetic character (A-Z)");
                        continue;
                    }

                    if (userInputStorage.Contains(userInput))
                    {
                        Console.WriteLine("You still tryed this Letter. Choose another one.");
                        continue;
                    }
                    userInputStorage.Add(userInput);

                    int startPosition = 0;
                    int foundPosition = randomWord.IndexOf(userInput, startPosition);

                    if (foundPosition == -1)
                    {
                        Console.WriteLine("\nLetter doesn't exists in the Word");
                        remainingTries--;
                    }

                    else
                    {
                        while (startPosition < length - 1)
                        {
                            unknownWord[foundPosition] = userInput;
                            startPosition = foundPosition + 1;
                            foundPosition = randomWord.IndexOf(userInput, startPosition);

                            if (foundPosition == -1)
                            {
                                break;
                            }
                        }
                        guessedWord = new string(unknownWord);
                        Console.WriteLine(unknownWord);
                    }

                    if (remainingTries == 0)
                    {
                        Console.WriteLine("\nSRY, YOU REACHED THE MAXIMUM TRIES!!!");
                        break;
                    }                   
                }

                if (guessedWord == randomWord)
                {
                    Console.WriteLine("\nCONGRATULATION YOU FOUND THE WORD!!!");
                    restartGame = Program.restartGame();
                }
                else
                {
                    restartGame = Program.restartGame();
                }   
            }

            Console.WriteLine("THANKS FOR PLAYING");
        }

        /// <summary>
        /// Possibility for user to play again
        /// </summary>
        /// <returns>true(User wants to play again) or false (he doesn't)</returns>
        static bool restartGame ()
        {
            Console.WriteLine("\nIF YOU WANT TO PLAY AGAIN, PRESS 'Y'");
            string restart = Console.ReadLine().ToUpper();
            bool playAgain = true;
            if (restart != "Y")
            {
                playAgain = false;
            }
            return playAgain;
        }

    }
}