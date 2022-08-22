# Hangman
Hangman is a game where a word is secretly chosen and the player guesses letters to fill in the word.
Each correct guess fills in that letter in the word. Guess too many wrong letters and the player loses.
Tips: It is all a matter of taking the letter the player guesses and looping through the word comparing it to each letter in the word character by character. If the letters match, you show that letter to the player. If you reach the end of the word and no letters have been matched, it is a wrong guess.
Remember that strings are often treated as an array of characters. Most languages have a function to fetch a single letter from a string.
Keep track of how many wrong guesses the player has done and use this number to determine if the game has been won or lost.
Added Difficulty: Increase the length of the words and choose more complex unknown words to have the player guess.

![image](https://user-images.githubusercontent.com/111677912/185781729-bc7397d9-af18-468e-95bb-e6e251fbe504.png)
