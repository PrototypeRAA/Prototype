using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool Abierta;
    public Vector3 RotacionAbierta;
    public Vector3 RotacionCerrada;

    private AudioSource audioSource;

    void Start()
    {
        if (Abierta)
            RotarPuerta(RotacionAbierta);
        else
            RotarPuerta(RotacionCerrada);

        audioSource = GetComponent<AudioSource>();
    }

    public void Abrir()
    {
        if (Abierta) return;
        Abierta = true;
        RotarPuerta(RotacionAbierta);

        if (audioSource != null) audioSource.Play();
    }

    public void Cerrar()
    {
        if (!Abierta) return;
        Abierta = false;
        RotarPuerta(RotacionCerrada);
    }

    private void RotarPuerta(Vector3 rotacion)
    {
        Debug.Log(rotacion);
        this.transform.localRotation = Quaternion.Euler(rotacion.x, rotacion.y, rotacion.z);
    }
}
