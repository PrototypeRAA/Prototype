using System;
using System.Collections;
using System.Collections.Generic;

public class DialoguePath
{
    public Action OnPathTaken;

    public string OptionName { get; private set; }
    public Dialogue Destination { get; private set; }
    
    //
    // Constructors
    //
    public DialoguePath(string optionName, Dialogue destination)
    {
        this.OptionName = optionName;
        this.Destination = destination;
    }

    //
    // Methods
    //

    public Dialogue TakePath()
    {
        OnPathTaken?.Invoke();
        Destination?.OnNodeArrival?.Invoke();
        return Destination;
    }
}
