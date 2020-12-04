using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomLevel1Script : AbstractInteractable
{
    
    private bool isPlaying;

    public AudioSource audioPortal;

    private float growthRate;

    void Start()
    {
        base.Start();
        isPlaying = false;
        growthRate = 0.01f;
    }

    void Update(){
        if(isPlaying){
        GrowPortal();
        }
    }


    public override void HaSidoMirado()
    {
        if(!isPlaying){
            audioPortal.PlayOneShot(audioPortal.clip);
            isPlaying = true;
        }
    }

    public void GrowPortal(){
        this.gameObject.transform.localScale += new Vector3(this.gameObject.transform.localScale.x + 
        growthRate,this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }

    
}
