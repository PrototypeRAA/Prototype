using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleL3Script : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider col){
    //Comprobar la tag del objeto con el que ha colisionado, si es el jugador, aplicar impulso
    //para superar el foso y parar movimiento para el aterrizaje
    if(col.tag == "Player"){
            Debug.Log("Game over");
        }

    }
}
