using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleForBallScript : MonoBehaviour
{

    public GameObject theOtherHole;

    public bool isFilled;

    public string ownTag;

    public GameObject puertaSala4;

    public AudioSource audioPuerta;

    public GameObject player;

    public GameObject lightForHole;

    public AudioSource audioCorrectBall;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        isFilled = false;
        ownTag = gameObject.tag;
        audioPuerta = puertaSala4.GetComponent<AudioSource>();

    }

     public void OnTriggerEnter(Collider col){
        if(col.tag == "BlueBallS4" && ownTag == "BlueHole"){
            isFilled = true;
            CheckOtherHole();
            ChangeHoleLight();
        }
        else if(col.tag == "RedBallS4" && ownTag == "RedHole"){
            isFilled = true;
            CheckOtherHole();
            ChangeHoleLight();
        }
        else if(col.tag == "Player"){
            Debug.Log("game over");
        }
    }

    public void ChangeHoleLight(){
        audioCorrectBall.PlayOneShot(audioCorrectBall.clip);
        Light lightComponent = lightForHole.GetComponent<Light>(); 
        lightComponent.range = 2;
        lightComponent.intensity = 0.2f;
        Color greenForHole = new Color(39f, 174f, 96f);
        lightComponent.color = greenForHole;
    }



    public void CheckOtherHole(){
        HoleForBallScript scriptFromOtherHole = theOtherHole.GetComponent<HoleForBallScript>();
        if(scriptFromOtherHole.isFilled){
            AbrirPuertaSala4();
        }
    }

    public void AbrirPuertaSala4(){
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        inventario.CambiarTexto("Sala 4 superada!");
        Debug.Log("Sala 4 superada");
        puertaSala4.transform.Rotate(0, 0, -90);
        Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
        scriptMovimiento.isMoving = false;
        audioPuerta.Play();
    }

}
