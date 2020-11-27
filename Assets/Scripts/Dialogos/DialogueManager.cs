using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class DialogueManager : MonoBehaviour
{
    public Animator animator;

    // Nombre del Interlocutor
    public Image characterPic;
    // Nombre del Interlocutor
    public TMP_Text nameText;
    // Sitio donde se escribe el diálogo
    public TMP_Text dialogueText;
    // Prefab de la opcion
    public GameObject prefabOpcion;

    public Vector3 PathsDisplayPosition { get; private set; }
    public DialogueTree CurrentDialogueTree { get; private set; }
    public Dialogue CurrentDialogue { get; private set; }


    GameObject[] listOfOptions;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Comienza el diálogo "dialogueTree", mostrando en pantalla su texto y mostrando en "OptionsPosition" las opciones
    public void StartDialogue(DialogueTree dialogueTree, Vector3 pathsDisplayPosition)
    {
        if(animator.GetBool("isOpen")) return;
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
        ErasePaths();
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

        // Mostrar las opciones del diálogo
        if (CurrentDialogue.Options.Count >= 2)
            ImprimirEnPantallaPaths(CurrentDialogue, PathsDisplayPosition, Vector3.left * 90);

        // Reproducir audio del diálogo
        if (CurrentDialogue.Sound != null) {
            audioSource.clip = CurrentDialogue.Sound;
            audioSource.Play();
        }

        // Comprobamos si se tiene que actualizar sola la caja de diálogos
        CheckForAutoUpdate();
    }
    
    public void EndDialogue(){
        animator.SetBool("isOpen", false);
    }

    public void ImprimirEnPantallaPaths(Dialogue dialogue, Vector3 pathsPosition, Vector3 pathsRotation){
        listOfOptions = new GameObject[dialogue.Options.Count];

        var y = 1;
        int i=0;
        foreach (DialoguePath path in dialogue.Options)
        {
            Vector3 tempTrans = pathsPosition;
            tempTrans -= Vector3.right * 2f;
            tempTrans += Vector3.up * y;
            GameObject g = Instantiate(prefabOpcion, tempTrans, Quaternion.Euler(pathsRotation.x, pathsRotation.y, pathsRotation.z));
            g.transform.Find("OptionText").GetComponent<TextMeshPro>().text = path.OptionName;
            g.AddComponent<OptionTrigger>();
            g.GetComponent<OptionTrigger>().path = path;
            g.GetComponent<OptionTrigger>().manager = this;
            listOfOptions[i] = g;
            i++;
            y -= 1;
        }
    }

    public void ErasePaths(){
        if (listOfOptions == null) return;

        for (int i=0;i<listOfOptions.Length;i++)
        {
            if (listOfOptions[i] != null)
                Destroy(listOfOptions[i]);
        }
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
            float timeBeforeSkip = GetDialogueSkipTime(CurrentDialogue);
            Invoke("AutoChooseOption", timeBeforeSkip);
        }
    }

    private float GetDialogueSkipTime(Dialogue d)
    {
        float intervalBetweenAudios = 0.25f;
        float timePerCharacter = 0.05f;

        float audioTime = d.Sound ? 
            d.Sound.length + intervalBetweenAudios  // Audio length plus a little
                : 
            0;

        float textTime = !string.IsNullOrEmpty(d.Text) ? 
            Mathf.Max(2, d.Text.Length * timePerCharacter) // 2secs if text is short or more if text is long
                : 
            0;
        
        return Mathf.Max(audioTime, textTime);
    }

    private void AutoChooseOption()
    {
        int choiceIndex = UnityEngine.Random.Range(0, CurrentDialogue.Options.Count - 1);
        this.PathTaken( CurrentDialogue.Options[choiceIndex] );
    }
}
