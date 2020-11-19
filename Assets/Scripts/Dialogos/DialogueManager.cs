using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public Animator animator;

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
        nameText.text = "Ordenador";

        // Muestra el diálogo actual en pantalla
        dialogueText.text = CurrentDialogue.Text;

        // TODO, enviar diálogo a un objeto que muestre las opciones de este, ejemlo: 
        // ImprimirEnPantallaPaths(Dialogue CurrentDialogue, Vector3 PathsDisplayPosition) - Nota, el segundo attributo determina en torno a donde se muestran las opciones
        // throw new NotImplementedException();
    }

    public void EndDialogue(){
        animator.SetBool("isOpen", false);
    }
}
