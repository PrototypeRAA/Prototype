using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpherePlaneScript : MonoBehaviour
{

    public GameObject player;

    public GameObject secondPlane;
    public GameObject thirdPlane;

    public GameObject doorRoom1Level2;

    public bool isActivated;

    private AudioSource audioPuerta;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        isActivated = false;
        audioPuerta = doorRoom1Level2.GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider col){
        if(col.tag == this.gameObject.tag){
            isActivated = true;
            CheckForRoomSolved();
        }
    }

        public void CheckForRoomSolved(){
        HoleLevel2Script scriptSecondPlane = secondPlane.GetComponent<HoleLevel2Script>();
        HoleLevel2Script scriptThirdPlane = thirdPlane.GetComponent<HoleLevel2Script>();

        if(scriptSecondPlane.isActivated && scriptThirdPlane.isActivated){
            OpenDoorRoom1();
        }
    }

    private void OpenDoorRoom1(){
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        inventario.CambiarTexto("Sala 3 superada!");
        doorRoom1Level2.transform.Rotate(0, 0, -90);
        Movimiento scriptMovimiento = player.GetComponent<Movimiento>();
        scriptMovimiento.isMoving = false;
        audioPuerta.PlayOneShot(audioPuerta.clip);
    }
}
