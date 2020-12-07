using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRoom3Script : MonoBehaviour
{
    public bool levelFinished;

    void Start()
    {
        levelFinished = false;
    }
    public void OnTriggerEnter(Collider col){
        if(col.tag == "Player" && !levelFinished){
            levelFinished = true;
            GameObject player = GameObject.FindWithTag("Player");
            GameObject doorRoom2Level2 = GameObject.FindWithTag("DoorRoom3Level2");
            AudioSource audioPuerta = doorRoom2Level2.GetComponent<AudioSource>();
            InventarioScript inventario = player.GetComponent<InventarioScript>();
            inventario.CambiarTexto("Nivel superado!");
            doorRoom2Level2.transform.Rotate(0, 0, -90);
            Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
            scriptMovimiento.isMoving = false;
            audioPuerta.PlayOneShot(audioPuerta.clip);
        }
    }
}
