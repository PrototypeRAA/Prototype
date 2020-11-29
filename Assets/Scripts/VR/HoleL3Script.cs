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
        if(col.tag == "Player"){
            Debug.Log("Game over");
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            if(!playerScript.isGameOver){
                playerScript.isGameOver = true;
                playerScript.GameOver();
            }
        }
    }
}
