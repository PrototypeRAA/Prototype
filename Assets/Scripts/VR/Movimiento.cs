using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
    private bool isMoving;
    void Start()
    {
        isMoving = false;
        //transform.Translate(0f,1.5f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving && !Input.GetButton("Fire1")){
            //Sacamos los valores de la dirección de la cámara del jugador
            float valueXAxis = Camera.main.transform.forward.x * Time.deltaTime * playerSpeed;
            float valueZAxis = Camera.main.transform.forward.z * Time.deltaTime * playerSpeed;
            //Movemos al jugador sin cambios en la altura
            transform.Translate(valueXAxis, 0f, valueZAxis);
            Debug.Log("Altura: " + transform.position.y);
        } else if(Input.GetButton("Fire1") && !isMoving){
            isMoving = true;
        }else if (Input.GetButton("Fire1") && isMoving){
            isMoving = false;
        }
    }
}
