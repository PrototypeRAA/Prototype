using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public AudioSource landingSound;

    private bool isActivated = false;

    public void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            if(this.gameObject.tag == "FinalPlatform" && !isActivated){
                isActivated = true;
                GameObject player = GameObject.FindWithTag("Player");
                GameObject doorRoom2Level2 = GameObject.FindWithTag("DoorRoom2Level2");
                AudioSource audioPuerta = doorRoom2Level2.GetComponent<AudioSource>();
                InventarioScript inventario = player.GetComponent<InventarioScript>();
                inventario.CambiarTexto("Sala 2 superada!");
                doorRoom2Level2.transform.Rotate(0, 0, -90);
                Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
                scriptMovimiento.isMoving = false;
                audioPuerta.PlayOneShot(audioPuerta.clip);
                landingSound.Play();
            }else if(this.gameObject.tag != "FinalPlatform"){
                landingSound.Play();
            }
        }
    }
}
