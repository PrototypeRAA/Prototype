using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderButtonL1 : AbstractInteractable
{
   
    public GameObject player; 

    public GameObject objetoMirado;

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
        Debug.Log("Entrada al botón");
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public override void OnPointerExit()
    {
        Debug.Log("Salida del botón");
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public override void HaSidoMirado()
    {
        Debug.Log("Botón activado");
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}