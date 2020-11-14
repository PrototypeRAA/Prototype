using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderButtonL2 : AbstractInteractable
{
    // Start is called before the first frame update
    void Start()
    {
        
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
    }

    public override void HaSidoMirado()
    {

    }
}
