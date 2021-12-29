using System;

namespace WordCorrection
{
    class Program
    {
        static void Main()
        {
            // Take the sentence
            string[] sentence = Console.ReadLine().Split();

            // Number of suggestions
            int n = Convert.ToInt32(Console.ReadLine());

            // Get the valid words
            string[] validWords = ReadValidWords(n);

            // I used the coundInvalidWords to check if the sentence is perfect
            int countInvalidWords = 0;

            // the result that will be modified and printed in some cases
            string result = "";

            foreach (string word in sentence)
            {
                // Check if the word is in the suggestions
                if (IsValidWord(validWords, word.ToLower()))
                {
                    continue;
                }

                // Increase the counter of the invalid words
                countInvalidWords++;

                // Get the suggestions
                string suggestions = GetWordCorrectionSuggestions(word, validWords);

                // If there are no suggestions then decrease the counter of the invalid words
                if (suggestions == " (nu sunt sugestii)")
                {
                    countInvalidWords--;
                }

                // Append the result
                result += word + ":" + suggestions + "\n";
            }

            // Print the result
            Console.WriteLine(countInvalidWords == 0 && n != 1 ? "Text corect!" : result);
        }

        static string[] ReadValidWords(int n)
        {
            // Read the suggestions and return them as a string array
            string[] validWords = new string[n];

            for (int i = 0; i < n; i++)
            {
                validWords[i] = Console.ReadLine();
            }

            return validWords;
        }

        static bool IsValidWord(string[] validWords, string word)
        {
            // Check if the word is in the array of suggestions
            foreach (string validW in validWords)
            {
                if (validW == word)
                {
                    return true;
                }
            }

            return false;
        }

        static string GetWordCorrectionSuggestions(string word, string[] validWords)
        {
            // Get all the possible suggestions for the word or specify that are no suggestions
            string valid = "";
            int counterValidWords = 0;

            foreach (string validWord in validWords)
            {
                if (SameLengthOneDiff(word.ToLower(), validWord) || ConsecutiveLetters(word.ToLower(), validWord)
                    || DeleteOneLetter(word.ToLower(), validWord) || DeleteOneLetter(validWord, word.ToLower()))
                {
                    valid += " " + validWord;
                    counterValidWords++;
                }
            }

            return counterValidWords > 0 ? valid : " (nu sunt sugestii)";
        }

        static bool SameLengthOneDiff(string word, string validWord)
        {
            // Check if the word has only one letter different from the valid word
            if (word.Length != validWord.Length)
            {
                return false;
            }

            int counterInvalid = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != validWord[i])
                {
                    counterInvalid++;
                }
            }

            return counterInvalid <= 1;
        }

        static bool ConsecutiveLetters(string word, string validWord)
        {
            // Check if there are 2 consecutive letters that if you
            // change then the word will become valid
            if (validWord.Length != word.Length)
            {
                return false;
            }

            if (validWord == Convert.ToString(word[1]) + Convert.ToString(word[0])
                + word.Substring(1 + 1, word.Length - 1 - 1))
            {
                return true;
            }

            for (int i = 2; i < word.Length; i++)
            {
                if (word.Substring(0, i - 1) + Convert.ToString(word[i]) +
                    Convert.ToString(word[i - 1]) + word.Substring(i + 1) == validWord)
                {
                    return true;
                }
            }

            return false;
        }

        static bool DeleteOneLetter(string word, string validWord)
        {
            // Check if you delete one letter then the word will become valid
            // I used this function also to check if you delete a letter from a valid
            // then will become the word
            if (word.Length != validWord.Length + 1)
            {
                return false;
            }

            if (word.Substring(1) == validWord)
            {
                return true;
            }

            for (int i = 1; i < word.Length; i++)
            {
                if (word.Substring(0, i) + word.Substring(i + 1) == validWord)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
