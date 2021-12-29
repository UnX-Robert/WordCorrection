# WordCorrection

Give a sentence on a line.
On the next line is a number N, followed by N lines with one valid word per line.

Write an application that analyzes the given phrase and displays suggestions for correcting words that were not found in the valid word list:

- Wrong letter words (valid words that are the same length as the word in the sentence, but a different letter)
- inverted two-letter words (valid words obtained by inverting two consecutive letters in the word in the sentence)
- words with an extra letter (valid words obtained by removing a single letter from the word in the sentence)
- words with one less letter (valid words obtained by adding a single letter to the word in the sentence)
- If the phrase contains only valid words, the message "Text corect!" will be displayed!
