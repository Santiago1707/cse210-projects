using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse; // Nullable for multi-verse references

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null; // Single verse reference
    }

    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse; // Multi-verse reference
    }

    public string GetDisplayText()
    {
        return _endVerse == null ? $"{_book} {_chapter}:{_verse}" : $"{_book} {_chapter}:{_verse}-{_endVerse}";
    }
}
