using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeLowPoly : AbstractInteractable
{

    public override void OnPointerEnter()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
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
