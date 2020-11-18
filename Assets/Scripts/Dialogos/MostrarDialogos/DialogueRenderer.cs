using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueRenderer : MonoBehaviour
{
    public Action<Dialogue> OnDialogueStart;

    public DialogueTree Tree;

    public Dialogue StartDialogue()
    {
        OnDialogueStart?.Invoke(Tree.Root);
        return Tree.Root;
    }
}
