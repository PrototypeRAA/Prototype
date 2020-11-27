using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : AbstractInteractable
{
    public DialogueTree Tree;
    DialogueManager manager;

    protected override void Start()
    {
        base.Start();
        manager = FindObjectOfType<DialogueManager>();
    }
    
    public override void HaSidoMirado(){
        manager.StartDialogue(Tree, transform.position);
    }
}
