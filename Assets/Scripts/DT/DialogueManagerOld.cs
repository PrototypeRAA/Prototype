using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerOld : MonoBehaviour
{
    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;

    void Start(){
        sentences = new Queue<string>();
    }

    public void StartDialogue (Dialogue2 dialogue){
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        if (sentences.Count == 0){
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue(){
        animator.SetBool("isOpen", false);
    }
}
