using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderButtonL1 : AbstractInteractable
{
   
    public GameObject player; 

    public GameObject objetoMirado;

    public GameObject puerta;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {}

    public override void OnPointerEnter(){
        Debug.Log("Entrada al botón");
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public override void OnPointerExit()
    {
        Debug.Log("Salida del botón");
    }

    public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        if(inventario.objetoEnInventario != null){
            GameObject cuboInventario = inventario.objetoEnInventario;
            GameObject copiaCubo = Instantiate(cuboInventario);
            copiaCubo.transform.position = new Vector3(objetoMirado.transform.position.x, objetoMirado.transform.position.y+2, objetoMirado.transform.position.z);
        }

    }

    public void OnTriggerEnter(Collider col){
        //Comprobar la tag del objeto con el que ha colisionado
        if(col.tag == "ObjectToPick"){
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
            InventarioScript inventario = player.GetComponent<InventarioScript>();
            inventario.CambiarTexto("Nivel 1 superado!");
            AbrirNivel2();
        }
    }

    private void AbrirNivel2(){
        Destroy(puerta);
    }
}