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
    public AudioSource audioPuerta;
    public AudioSource audioBtn;
    public AudioSource audioClick;

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
        ColliderButtonL2 colliderOtroBtn = theOtherButton.GetComponent<ColliderButtonL2>();
        if(col.tag == "ObjectInButton"){
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            InventarioScript inventario = player.GetComponent<InventarioScript>();
            //Abrir nivel 2 y vaciar inventario
            inventario.objetoEnInventario = null;
            activado = true;
            audioBtn.PlayOneShot(audioBtn.clip);
            if(colliderOtroBtn.activado){
                this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                activado = true;
                AbrirPuertaNivel2();
            }
        }
        else if(col.tag == "Player"){
            audioClick.PlayOneShot(audioClick.clip);
            activado = true;
            if(colliderOtroBtn.activado){
                this.gameObject.GetComponent<Renderer>().material.color = Color.green;
                activado = true;
                AbrirPuertaNivel2();
            }
        }
    }
    private void AbrirPuertaNivel2(){
        //Abrir nivel 2 y vaciar inventario
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        inventario.CambiarTexto("Sala 2 superada!");
        puertaNivel2.transform.Rotate(0, 0, -90);
        Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
        scriptMovimiento.isMoving = false;
        audioPuerta.Play();
    }


    public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        if(inventario.objetoEnInventario != null){
            //Copiar cubo y poner el nuevo encima del botón
            GameObject cuboInventario = inventario.objetoEnInventario;
            GameObject copiaCubo = Instantiate(cuboInventario);
            copiaCubo.SetActive(true);
            copiaCubo.transform.position = new Vector3(objetoMirado.transform.position.x, objetoMirado.transform.position.y+2, objetoMirado.transform.position.z);
            copiaCubo.gameObject.tag = "ObjectInButton";
            //Eliminar collider del nuevo cubo para que no se pueda interaccionar con él
            ColliderLowPolyBox colliderBox = copiaCubo.GetComponent<ColliderLowPolyBox>();
            Destroy(colliderBox);
            activado = true;
        }
    }
}
