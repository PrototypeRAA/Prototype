using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallPlaneScript : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

   
    public void OnTriggerEnter(Collider col){
        if(col.tag == "Player"){
            PlayerScript playerScript = player.GetComponent<PlayerScript>();
            playerScript.GameOverLevel2();
        }
    }
}
