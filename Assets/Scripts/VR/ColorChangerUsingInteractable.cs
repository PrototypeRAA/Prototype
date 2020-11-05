using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerUsingInteractable : AbstractInteractable
{
    /*
    // Si vamos a usar Start en la subclase, llamamos primero a la super, para que añada las llamadas a los métodos en el EventTrigger
    protected override void Start()
    {
        base.Start();
    }
    */

    public override void OnPointerClick()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public override void OnPointerEnter()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public override void OnPointerExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }

    public override void HaSidoMirado()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.green;
    }
}
