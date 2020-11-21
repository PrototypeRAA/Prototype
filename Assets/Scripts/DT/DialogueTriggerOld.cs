using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerOld : MonoBehaviour
{
    public Dialogue2 dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManagerOld>().StartDialogue(dialogue);
    }
}
