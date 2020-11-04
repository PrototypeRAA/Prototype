using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GvrPointerGraphicRaycaster))]
public class ColliderClickChangeColour : MonoBehaviour
{
    
    public void OnPointerClick()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void OnPointerEnter()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnPointerExit()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}