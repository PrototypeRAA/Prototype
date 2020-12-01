using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStairScript : AbstractInteractable
{
    public GameObject player;

    public bool planeActivated;
    public GameObject otherPiece1;
    public GameObject otherPiece2;
    public GameObject puertaSala5;

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
            //Vaciado de inventario
            inventario.objetoEnInventario = null;
            CheckForFullStair();
            this.gameObject.SetActive(false);
            }
        }
    }

    public void CheckForFullStair(){
        PlaneStairScript otherPlane1 = otherPiece1.GetComponent<PlaneStairScript>();
        PlaneStairScript otherPlane2 = otherPiece2.GetComponent<PlaneStairScript>();

        if(otherPlane1.planeActivated && otherPlane2.planeActivated){
            AbrirPuertaSala5();
        }
    }


    public void AbrirPuertaSala5(){
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        inventario.CambiarTexto("Sala 5 superada!");
        puertaSala5.transform.Rotate(0, 0, -90);
        Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
        scriptMovimiento.playerSpeed = 7;
        scriptMovimiento.isMoving = false;
    }
}
