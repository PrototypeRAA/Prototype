using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole2L3Script : AbstractInteractable
{

    public GameObject player;

    public GameObject foso;

    public GameObject puertaSala3;

    public AudioSource audioPuerta;


    void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        foso = GameObject.FindWithTag("HoleL2");
        audioPuerta = puertaSala3.GetComponent<AudioSource>();
    }

    public override void OnPointerEnter()
    {
        Debug.Log("Entrada al foso");
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }


    public override void OnPointerExit()
    {
        Debug.Log("Salida del foso");
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }


    public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        if(inventario.objetoEnInventario != null){
            GameObject cuboInventario = inventario.objetoEnInventario;
            GameObject copiaCubo = Instantiate(cuboInventario);
            copiaCubo.transform.position = new Vector3(foso.transform.position.x, foso.transform.position.y+2, foso.transform.position.z);
            copiaCubo.gameObject.tag="ObjectInHole";
            ColliderLowPolyBox colliderBox = copiaCubo.GetComponent<ColliderLowPolyBox>();
            Destroy(colliderBox);
            GvrPointerGraphicRaycaster gaze = copiaCubo.GetComponent<GvrPointerGraphicRaycaster>();
            Destroy(gaze);
            GameObject cuboInicial = GameObject.FindGameObjectsWithTag("ObjectForHole")[0];
            Destroy(cuboInicial);
        }
    }

    public void OnTriggerEnter(Collider col){
        if(col.tag == "ObjectInHole"){
            Debug.Log("Sala 3 superada");
            AbrirPuertaSala3();
        }
    }

    private void AbrirPuertaSala3(){
        puertaSala3.transform.Rotate(0, 0, -90);
        Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
        scriptMovimiento.isMoving = false;
        audioPuerta.Play();
    }


}
