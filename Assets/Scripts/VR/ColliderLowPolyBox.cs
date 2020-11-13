using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLowPolyBox : AbstractInteractable
{

    public GameObject player; 

    public GameObject objetoMirado;

    public bool inventarioVacio;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnPointerEnter(){
        Debug.Log("Entrada al cubo");
    }

    public override void OnPointerExit()
    {
        Debug.Log("Salida del cubo");
    }

    public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        inventario.NuevoObjetoEnInventario(objetoMirado);
    }
}
