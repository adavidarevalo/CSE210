using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public Reference Reference { get; }
    private List<Word> _words;
    private static Random _rng = new Random();

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        _words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public void HideRandomWords(int count)
    {
    var visible = _words.Where(w => !w.IsHidden).ToList();
        if (visible.Count == 0) return;

        int toHide = Math.Min(count, visible.Count);
        for (int i = 0; i < toHide; i++)
        {
            var idx = _rng.Next(visible.Count);
            visible[idx].Hide();
            visible.RemoveAt(idx);
        }
    }

    public bool AllHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public override string ToString()
    {
        var text = string.Join(' ', _words.Select(w => w.ToString()));
        return $"{Reference}\n{text}";
    }
}
