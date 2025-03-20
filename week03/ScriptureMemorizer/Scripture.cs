using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        // Split text into words and store them as Word objects
        string[] wordsArray = text.Split(' ');
        foreach (string word in wordsArray)
        {
            _words.Add(new Word(word));
        }
    }
    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.FindAll(word => !word.IsHidden()); // Get all words that are still visible

        int wordsToHide = Math.Min(count, visibleWords.Count); // Don't exceed available visible words

        for (int i = 0; i < wordsToHide; i++)
        {
            int index = _random.Next(visibleWords.Count); // Pick a random visible word
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index); // Remove from list to avoid hiding the same word twice
        }
    }


    public string GetDisplayText()
    {
        string displayedText = "";
        foreach (Word word in _words)
        {
            displayedText += word.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()}\n{displayedText.Trim()}";
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}
