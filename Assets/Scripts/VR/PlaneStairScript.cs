using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStairScript : AbstractInteractable
{
    public GameObject player;

    public bool planeActivated;
    public GameObject otherPiece1;
    public GameObject otherPiece2;

    void Start()
    {
        base.Start();
        planeActivated = false;   
        player = GameObject.FindWithTag("Player");
    }

    public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        if(inventario.objetoEnInventario != null){
            if(inventario.objetoEnInventario.tag == this.gameObject.tag){
            GameObject piezaEscaleraInventario = inventario.objetoEnInventario;
            GameObject copiaPiezaEscalera = Instantiate(piezaEscaleraInventario);
            copiaPiezaEscalera.SetActive(true);
            copiaPiezaEscalera.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+0.25f, this.gameObject.transform.position.z);
            copiaPiezaEscalera.gameObject.tag = "ObjectInButton";
            //Eliminar collider de la pieza para que no se pueda interaccionar con ella
            ColliderLowPolyBox colliderBox = copiaPiezaEscalera.GetComponent<ColliderLowPolyBox>();
            Destroy(colliderBox);
            planeActivated  = true;
            }
        }
    }
}
