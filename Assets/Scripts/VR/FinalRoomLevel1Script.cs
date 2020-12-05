using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class FinalRoomLevel1Script : AbstractInteractable
{
    
    private bool isPlaying;
    
    public GameObject player;

    public PlayerScript playerScript;

    public AudioSource audioPortal;

    void Start()
    {
        base.Start();
        isPlaying = false;
        playerScript = player.GetComponent<PlayerScript>();
    }

    void Update(){
        if(isPlaying){
            StartWarping();
        }
    }


    public override void HaSidoMirado()
    {
        this.gameObject.GetComponent<Renderer>().material.color = Color.magenta;
        if(!isPlaying){
            audioPortal.PlayOneShot(audioPortal.clip);
            isPlaying = true;
            TransitionWithDelay();
        }
    }

    public async void TransitionWithDelay(){
        Task waitForLevelTransition =  Task.Delay(1000);
        await waitForLevelTransition;
        playerScript.TransitionToNextLevel();
    }

    public void StartWarping(){
        Camera.main.fieldOfView = Camera.main.fieldOfView + 0.3f;
    }

    
}
