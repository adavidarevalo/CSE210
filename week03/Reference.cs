using System;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int? _endVerse;

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_endVerse.HasValue && _endVerse.Value != _startVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse.Value}";
        }
        else
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }
    }
}
