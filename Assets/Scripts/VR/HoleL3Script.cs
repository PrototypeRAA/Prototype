using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleL3Script : MonoBehaviour
{
    GameObject player;
  

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void OnTriggerEnter(Collider col){
    //Comprobar la tag del objeto, puede ser el jugador (game over) o el cubo (sala superada, abrir puerta)
        if(col.tag == "Player"){
            Debug.Log("Game over");
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.GameOver();
        }
    }
}
