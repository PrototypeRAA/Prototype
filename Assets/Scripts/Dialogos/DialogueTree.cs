using System;
using System.Collections;
using System.Collections.Generic;

public class DialogueTree
{
    public Dialogue Root { get; private set; }
    public List<Dialogue> Dialogues { get; private set; } = new List<Dialogue>();
    
    //
    // Constructors
    //

    public DialogueTree() { }

    public DialogueTree(Dialogue root) : this() {
        this.Root = root;
        Dialogues.Add(root);
    }

    //
    // Methods
    //

    public void AddDialogue(Dialogue dialogue)
    {
        if (Root == null) Root = dialogue;
        Dialogues.Add(dialogue);
    }
}
