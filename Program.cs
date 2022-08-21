namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Liste (wholeList) mit 10 Wörtern erstellen

            List<string> wordList = new List<string>() { "RAKETE", "PROGRAMMING", "CODING", "HONULULU", "MENTORING" };
            List<char> userInputStorage = new List<char>();

            //züfälliges Wort aus Liste auswählen und in einen String (randomWord)

            Random randomGenerator = new Random();
            int choosenWord = randomGenerator.Next(wordList.Count);
            string randomWord = wordList[choosenWord];

            Console.WriteLine($"the random Word is {randomWord}");

            //Länge von "randomWord" herausfinden
                    
            int length = randomWord.Length;

            Console.WriteLine($"the word has {length} Letters");

            //Array "unknownWord" erstellen (Länge = Anzahl der Buchstaben von "randomWord") und Plätze mit "_" befüllen

            char[] unknownWord = new char[length];

            for (int pos = 0; pos < length; pos++)
            {
                unknownWord[pos] = '_';
                Console.Write(unknownWord[pos]);
            }

            //Anzahl der Versuche definieren "counterMaximumTrys"

            int counterMaxTrys = 10;

            //Auslöser für "Gewonnen" definieren

            string finishingGame = ""; 

            //while-Schleife erstellen und User schätzen lassen

            while (finishingGame != randomWord)
            {
                Console.Write($"\nTry to find the word (you still have {counterMaxTrys} Trys):\t");

                //Usereingabe auf korrekte Eingabe und erneute Eingabe eines bereits verwendeten Buchstaben überprüfen
                
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
                
                //Schätzung des Users durch "randomWord" laufen lassen und auf Gleichheit der Buchstaben vergleichen lassen

                int startPosition = 0;
                int foundPosition = randomWord.IndexOf(userInput, startPosition);

                if (foundPosition == -1)
                {
                    Console.WriteLine("\nLetter doesn't exists in the Word");
                    counterMaxTrys--;
                }

                //wenn Gleicheit gefunden wird, selbige Position in "unknownWord" durch entsprechenden Buchstaben ersetzen (Achtung: bei mehreren gleichen Buchstaben alle gleichen Buchstaben ersetzen!!!)                             
                
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
                    finishingGame = new string(unknownWord);
                    Console.WriteLine(unknownWord);                   
                }               

                if (counterMaxTrys == 0)
                {
                    Console.WriteLine("\nSRY, YOU REACHED THE MAXIMUM TRY'S!!!");
                    break;
                }             
            }

            //wenn alle Buchstaben gefunden wurden "GEWONNEN"

            Console.WriteLine("\nCONGRATULATION YOU FOUND THE WORD!!!");
        }
    }
}