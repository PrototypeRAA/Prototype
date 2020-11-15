using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderButtonL2 : AbstractInteractable
{


    public bool activado;
    public GameObject theOtherButton;
    public GameObject objetoMirado;
    public GameObject player;
    public GameObject puertaNivel2;

    void Start()
    {
        base.Start();
        activado = false;    
        player = GameObject.FindWithTag("Player");
    }


    public override void OnPointerEnter(){
        Debug.Log("Entrada al botón");
        if(!activado){
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
    public override void OnPointerExit()
    {
        Debug.Log("Salida del botón");
        if(!activado){
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void OnTriggerEnter(Collider col){
        //Comprobar la tag del objeto con el que ha colisionado
        if(col.tag == "ObjectInButton"){
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            InventarioScript inventario = player.GetComponent<InventarioScript>();
            //Abrir nivel 2 y vaciar inventario
            inventario.objetoEnInventario = null;
            activado = true;
        }
        else if(col.tag == "Player"){
            ColliderButtonL2 colliderOtroBtn = theOtherButton.GetComponent<ColliderButtonL2>();
            if(colliderOtroBtn.activado){
                InventarioScript inventario = player.GetComponent<InventarioScript>();
                //Abrir nivel 2 y vaciar inventario
                inventario.CambiarTexto("Nivel 2 superado!");
                player.transform.position = new Vector3(objetoMirado.transform.position.x, objetoMirado.transform.position.y+3, objetoMirado.transform.position.z);
                this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                activado = true;
                AbrirPuertaNivel2();
            }
        }
    }
    private void AbrirPuertaNivel2(){
        puertaNivel2.transform.Rotate(0, 0, 90);
        Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
        scriptMovimiento.isMoving = false;
    }


    public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        if(inventario.objetoEnInventario != null){
            //Copiar cubo y poner el nuevo encima del botón
            GameObject cuboInventario = inventario.objetoEnInventario;
            GameObject copiaCubo = Instantiate(cuboInventario);
            copiaCubo.transform.position = new Vector3(objetoMirado.transform.position.x, objetoMirado.transform.position.y+2, objetoMirado.transform.position.z);
            copiaCubo.gameObject.tag = "ObjectInButton";
            //Eliminar collider del nuevo cubo para que no se pueda interaccionar con él
            ColliderLowPolyBox colliderBox = copiaCubo.GetComponent<ColliderLowPolyBox>();
            Destroy(colliderBox);

            //Eliminar cubo antiguo
            GameObject cuboInicial = GameObject.FindGameObjectsWithTag("ObjectToPickL2")[0];
            Destroy(cuboInicial);
            activado = true;
        }
    }
}
