using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class SpringScript : MonoBehaviour
{
    GameObject player;
    GameObject spring;

    public AudioClip springSound;
    public AudioClip landingSound;
    public AudioSource audioSpring;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spring = this.gameObject;
    }

    public void OnTriggerEnter(Collider col){
    //Comprobar la tag del objeto con el que ha colisionado, si es el jugador, aplicar impulso,
    //cambiar disposición del trampolín y reproducir sonidos asociados (despegue y aterizaje)
    if(col.tag == "Player"){
            Vector3 springImpulse = new Vector3(6.0f, 5.0f, 0.0f);
            player.GetComponent<Rigidbody>().AddForce(springImpulse, ForceMode.Impulse);
            player.GetComponent<Movimiento>().isMoving = false;
            Vector3 scaleChangeFullSpring = new Vector3(0f, 44f, 0f);
            spring.transform.localScale += scaleChangeFullSpring;
            audioSpring.PlayOneShot(springSound,0.8f);
            PlayLandingSound();
        }

    }


    public async void PlayLandingSound(){
        Task waitToPlayLandingSound =  Task.Delay((int)1 * 1000);
        await waitToPlayLandingSound;
        audioSpring.PlayOneShot(landingSound, 0.8f);
    }
}
