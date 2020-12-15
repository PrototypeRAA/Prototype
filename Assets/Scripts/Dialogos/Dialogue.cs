using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{
    public Action OnNodeArrival;
    public Action OnNodeLeave;


    public string Speaker { get; set; }
    public Sprite Sprite { get; set; }
    public string Text { get; private set; }
    public List<DialoguePath> Options { get; private set; } = new List<DialoguePath>();
    public AudioClip Sound { get; set; }


    /// Default Option goes to no dialogue => Ends conversation
    private bool IsDefaultOptionIncluded = true;
    private DialoguePath DefaultOption = new DialoguePath("default", null);

    //
    // Constructors
    //
    
    public Dialogue(string text)
    {
        this.Text = text;
        Options.Add(DefaultOption);
    }

    public Dialogue(string text, string speaker) : this(text)
    {
        this.Speaker = speaker;
    }

    public Dialogue(string text, string speaker, Sprite sprite) : this(text, speaker)
    {
        this.Sprite = sprite;
    }

    public Dialogue(string text, List<DialoguePath> options) : this(text)
    {
        Options = new List<DialoguePath>(options);
        IsDefaultOptionIncluded = false;
    }

    //
    // Methods
    //

    public void AddOption(DialoguePath option)
    {
        if (IsDefaultOptionIncluded) IsDefaultOptionIncluded = !Options.Remove(DefaultOption); // Erase default option, no needed if we have one option
        Options.Add(option);
    }

    public Dialogue TakePath(DialoguePath option)
    {
        if (!Options.Contains(option)) throw new Exception( String.Format("El diálogo {0} no contiene la opción {1}", this, option) );

        OnNodeLeave?.Invoke();
        return option.TakePath();
    }
}
