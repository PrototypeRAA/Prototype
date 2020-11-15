using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderButtonL1 : AbstractInteractable
{
   
    public GameObject player; 

    public GameObject objetoMirado;

    public GameObject puertaNivel1;

    private bool finalizado;

    void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        finalizado = false;
    }


    public override void OnPointerEnter(){
        Debug.Log("Entrada al botón");
        if(!finalizado){
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    public override void OnPointerExit()
    {
        Debug.Log("Salida del botón");
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
            GameObject cuboInicial = GameObject.FindGameObjectsWithTag("ObjectToPick")[0];
            Destroy(cuboInicial);
        }

    }

    public void OnTriggerEnter(Collider col){
        //Comprobar la tag del objeto con el que ha colisionado
        if(col.tag == "ObjectInButton"){
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            finalizado = true;
            InventarioScript inventario = player.GetComponent<InventarioScript>();
            //Abrir nivel 2 y vaciar inventario
            inventario.CambiarTexto("Nivel 1 superado!");
            inventario.objetoEnInventario = null;
            AbrirPuertaNivel1();
        }
    }

    private void AbrirPuertaNivel1(){
        puertaNivel1.transform.Rotate(0, 0, 90);
    }
}