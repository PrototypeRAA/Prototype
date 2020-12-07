using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleLevel2Script : AbstractInteractable
{
    public GameObject player;

    public GameObject secondPlane;
    public GameObject spherePlane;

    public GameObject doorRoom1Level2;

    public bool isActivated;

    private AudioSource audioPuerta;

    public AudioSource audioHole;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("Player");
        isActivated = false;
        audioPuerta = doorRoom1Level2.GetComponent<AudioSource>();
    }

       public override void HaSidoMirado()
    {
        InventarioScript inventario = player.GetComponent<InventarioScript>();
        if(inventario.objetoEnInventario != null){
            if(inventario.objetoEnInventario.tag == this.gameObject.tag){
                audioHole.PlayOneShot(audioHole.clip);
                isActivated = true;
                GameObject objetoADuplicar = inventario.objetoEnInventario;
                GameObject copiaObjeto = Instantiate(objetoADuplicar);
                copiaObjeto.SetActive(true);
                copiaObjeto.transform.position = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y+2, this.gameObject.transform.position.z);
                ColliderLowPolyBox colliderBox = objetoADuplicar.GetComponent<ColliderLowPolyBox>();
                Destroy(colliderBox);
                GvrPointerGraphicRaycaster gaze = objetoADuplicar.GetComponent<GvrPointerGraphicRaycaster>();
                Destroy(gaze);
                CheckForRoomSolved();
                inventario.objetoEnInventario = null;
            }
            
        }
    }

    public void CheckForRoomSolved(){
        HoleLevel2Script scriptSecondPlane = secondPlane.GetComponent<HoleLevel2Script>();
        SpherePlaneScript scriptSpherePlane = spherePlane.GetComponent<SpherePlaneScript>();

        if(scriptSecondPlane.isActivated && scriptSpherePlane.isActivated){
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
