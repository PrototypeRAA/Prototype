using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleL2ColliderScript : MonoBehaviour
{
        public void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            GameObject player = GameObject.FindWithTag("Player");
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.GameOverLevel2();
        }
    }
}
