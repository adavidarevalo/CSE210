using System;

public class Word
{
    private string _text;
    private bool _hidden;

    public Word(string text)
    {
        _text = text;
        _hidden = false;
    }

    public void Hide()
    {
        _hidden = true;
    }

    public bool IsHidden => _hidden;

    public override string ToString()
    {
        if (_hidden)
        {
            return new string('_', Math.Max(1, _text.Length));
        }
        return _text;
    }
}
