using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionTrigger : AbstractInteractable
{
    public DialoguePath path;
    public DialogueManager manager;

    public override void HaSidoMirado(){
        float timeBeforeSkip = 2f;
        Invoke("TakeThePath", timeBeforeSkip);
    }

    public void TakeThePath(){
        manager.PathTaken(path);
    }

}
