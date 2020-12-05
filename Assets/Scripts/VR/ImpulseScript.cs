using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpulseScript : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider col){
        //Comprobar la tag del objeto con el que ha colisionado, si es el jugador, aplicar impulso,
        //cambiar disposición del trampolín y reproducir sonidos asociados (despegue y aterizaje)
        if(col.tag == "Player"){
            float cameraValueX = Camera.main.transform.forward.x;
            float cameraValueZ = Camera.main.transform.forward.z;
            Vector3 springImpulse = new Vector3(cameraValueX, 5.0f, cameraValueZ);
            Debug.Log(cameraValueX);
            Debug.Log(cameraValueZ);
            player.GetComponent<Rigidbody>().AddForce(springImpulse, ForceMode.Impulse);
        }
    }
}
