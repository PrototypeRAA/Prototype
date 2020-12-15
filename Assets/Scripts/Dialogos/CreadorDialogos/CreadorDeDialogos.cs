using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CreadorDeDialogos : MonoBehaviour
{
    public DialogueCreator[] Dialogues;
    public DialogueTrigger Trigger;
    public DialogueTree Tree { get; private set; }

    void Start()
    {
        Tree = new DialogueTree();

        Dictionary<int, Dialogue> dialogueMap = new Dictionary<int, Dialogue>();
        Dialogues.ToList().ForEach( d => dialogueMap.Add(d.id, d.ToDialogueWithoutOptions() ) );

        foreach (var item in Dialogues)
        {
            Dialogue d = dialogueMap[item.id];
            Tree.AddDialogue(d);
            for (int i = 0; i < item.OptionsText.Length; i++)
            {
                string currentPath = item.OptionsText[i];
                int currentDestination = item.OptionsDestination[i];

                Dialogue destination = null;
                if (currentDestination >= 0) destination = dialogueMap[currentDestination];

                d.AddOption(new DialoguePath(currentPath, destination));
            }
        }

        Trigger.Tree = this.Tree;
    }
}

[System.Serializable]
public struct DialogueCreator{
    public int id;

    public string Speaker;
    public Sprite Sprite;
    public string Text;
    public AudioClip Sound;

    public string[] OptionsText;
    public int[] OptionsDestination;

    public UnityEvent[] OnNodeArrival;
    public UnityEvent[] OnNodeLeave;

    public Dialogue ToDialogueWithoutOptions()
    {
        // Como las lambda expression no pueden hacer referencia a this, se requieren estas variables locales
        UnityEvent[] eventosOnArrival = OnNodeArrival;
        UnityEvent[] eventosOnLeave = OnNodeLeave;

        Dialogue d = new Dialogue(this.Text, this.Speaker, this.Sprite);
        d.Sound = this.Sound;
        d.OnNodeArrival += () => {
            if (eventosOnArrival != null)
                eventosOnArrival.ToList().ForEach(g => g.Invoke());
        };
        d.OnNodeLeave += () => {
            if (eventosOnLeave != null)
                eventosOnLeave.ToList().ForEach(g => g.Invoke());
        };
        return d;
    }
}