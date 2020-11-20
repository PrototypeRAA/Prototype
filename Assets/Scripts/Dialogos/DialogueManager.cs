using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;

    // Nombre del Interlocutor
    public Image characterPic;
    // Nombre del Interlocutor
    public TMP_Text nameText;
    // Sitio donde se escribe el diálogo
    public TMP_Text dialogueText;

    public Vector3? PathsDisplayPosition { get; private set; }
    public DialogueTree CurrentDialogueTree { get; private set; }
    public Dialogue CurrentDialogue { get; private set; }
    

    // Comienza el diálogo "dialogueTree", mostrando en pantalla su texto y mostrando en "OptionsPosition" las opciones
    public void StartDialogue(DialogueTree dialogueTree, Vector3? pathsDisplayPosition = null)
    {
        animator.SetBool("isOpen", true);
        CurrentDialogueTree = dialogueTree;
        PathsDisplayPosition = pathsDisplayPosition;

        CurrentDialogue = CurrentDialogueTree.Root;
        DialogueUpdate();
    }

    // Escoge el camino "path" del diálogo actual
    public void PathTaken(DialoguePath path)
    {
        CurrentDialogue = CurrentDialogue.TakePath(path);
        DialogueUpdate();
    }

    private void DialogueUpdate()
    {
        // Is this the last dialogue
        if (CurrentDialogue == null) {
            EndDialogue();
            return;
        }

        // Update picture and speaker name
        characterPic.sprite = CurrentDialogue.Sprite; //Resources.Load<Sprite>("Sprites/UI/Dialogue/pc_icon");
        if ( !nameText.text.Equals(CurrentDialogue.Speaker) )
            StartCoroutine( RevealWords(nameText, CurrentDialogue.Speaker) );

        // Muestra el diálogo actual en pantalla
        dialogueText.text = CurrentDialogue.Text;

        // TODO, enviar diálogo a un objeto que muestre las opciones de este, ejemlo: 
        // ImprimirEnPantallaPaths(Dialogue CurrentDialogue, Vector3 PathsDisplayPosition) - Nota, el segundo attributo determina en torno a donde se muestran las opciones
        // throw new NotImplementedException();


        // Comprobamos si se tiene que actualizar sola la caja de diálogos
        CheckForAutoUpdate();
    }
    
    public void EndDialogue(){
        animator.SetBool("isOpen", false);
    }




    IEnumerator RevealWords(TMP_Text textComponent, string text)
    {
        int totalChars = text.Length;
        System.Text.StringBuilder b = new System.Text.StringBuilder();

        int i = 0;
        while (i < totalChars)
        {
            b.Append(text[i]);

            textComponent.text = b.ToString();

            i++;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void CheckForAutoUpdate()
    {
        if (CurrentDialogue.Options.Count < 2)
        { // Auto choose next option
            float timeBeforeSkip = 2f;
            Invoke("AutoChooseOption", timeBeforeSkip);
        }
    }

    private void AutoChooseOption()
    {
        int choiceIndex = UnityEngine.Random.Range(0, CurrentDialogue.Options.Count - 1);
        this.PathTaken( CurrentDialogue.Options[choiceIndex] );
    }
}
