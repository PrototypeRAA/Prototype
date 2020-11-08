using System;
using System.Collections;
using System.Collections.Generic;

public class Dialogue
{
    public Action OnNodeArrival;
    public Action OnNodeLeave;

    public string Text { get; private set; }
    public List<DialoguePath> Options { get; private set; } = new List<DialoguePath>();

    //
    // Constructors
    //
    
    public Dialogue(string text)
    {
        this.Text = text;
    }

    public Dialogue(string text, List<DialoguePath> options) : this(text)
    {
        Options = new List<DialoguePath>(options);
    }

    //
    // Methods
    //

    public void AddOption(DialoguePath option)
    {
        Options.Add(option);
    }

    public Dialogue TakePath(DialoguePath option)
    {
        if (!Options.Contains(option)) throw new Exception( String.Format("El diálogo {0} no contiene la opción {1}", this, option) );

        OnNodeLeave?.Invoke();
        return option.TakePath();
    }
}
