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

        // Dialogo de prueba
        Tree = new DialogueTree();

        Dialogue Root = new Dialogue("La raíz");

        Dialogue DialogoOpcion1 = new Dialogue("Estás en el diálogo 1");
        Dialogue DialogoOpcion2 = new Dialogue("Estás en el diálogo 2");
        Dialogue DialogoOpcion3 = new Dialogue("Estás en el diálogo 3");

        Root.AddOption(new DialoguePath("Ir a 1", DialogoOpcion1) );
        Root.AddOption(new DialoguePath("Ir a 2", DialogoOpcion2) );
        DialogoOpcion1.AddOption(new DialoguePath("Ir a 3 desde 1", DialogoOpcion3) );
        DialogoOpcion2.AddOption(new DialoguePath("Ir a 3 desde 2", DialogoOpcion3) );

        Tree.AddDialogue(Root);
        Tree.AddDialogue(DialogoOpcion1);
        Tree.AddDialogue(DialogoOpcion2);
        Tree.AddDialogue(DialogoOpcion3);
    }
    
    public override void HaSidoMirado(){
        manager.StartDialogue(Tree);
        StartCoroutine(PruebaInteraccion());
    }

    IEnumerator PruebaInteraccion()
    {
        yield return new WaitForSeconds(2f);
        List<DialoguePath> options = manager.CurrentDialogue.Options;
        System.Random r = new System.Random();
        manager.PathTaken( options[ r.Next(0, options.Count)] );

        yield return new WaitForSeconds(2f);
        options = manager.CurrentDialogue.Options;
        manager.PathTaken(options[r.Next(0, options.Count)]);

        // Como solo hay 2 caminos, ahora debería terminar
        yield return new WaitForSeconds(2f);
        manager.EndDialogue();
    }
}
