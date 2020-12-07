using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;


public class BarrelsScript : MonoBehaviour
{
    private int timeSpan;

    public AudioSource waterLeakAudio;

    System.Random r = new System.Random();

    void Start()
    {
       PlaySoundWithTimeSpan();
    }

    public async void PlaySoundWithTimeSpan(){
        waterLeakAudio.PlayOneShot(waterLeakAudio.clip);
        int segundosEspera = r.Next(6,12);
        Task waitToDeleteText =  Task.Delay((int)segundosEspera * 1000);
        await waitToDeleteText;

    }
}
