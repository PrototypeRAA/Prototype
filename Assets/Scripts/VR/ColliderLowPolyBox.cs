using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLowPolyBox : AbstractInteractable
{
    public PlayerScript player;

    public GameObject objetoMirado;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = (PlayerScript) FindObjectOfType(typeof(PlayerScript));
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
        Debug.Log("Límite de tiempo alcanzado");
        InventarioScript inventario = player.inventario;
        player.inventario.NuevoObjetoEnInventario(objetoMirado);
        Debug.Log("Nuevo objeto añadido al inventario");
    }
}
