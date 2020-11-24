using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTrigger : AbstractInteractable
{
    public DialoguePath path;
    public DialogueManager manager;

    public override void HaSidoMirado(){
        TakeThePath();
    }

    public void TakeThePath(){
        manager.PathTaken(path);
    }

}
