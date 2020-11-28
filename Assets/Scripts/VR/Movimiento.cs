using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public int playerSpeed;
    public bool isMoving;
    void Start()
    {
        isMoving = false;
    }

    void Update()
    {
        //Movimiento activado
        if(isMoving && !Input.GetButton("Fire1")){

            //Obtenemos los valores de la cámara del usuario
            float valueXAxis = Camera.main.transform.forward.x * Time.deltaTime * playerSpeed;
            float valueZAxis = Camera.main.transform.forward.z * Time.deltaTime * playerSpeed;

            //Movemos al jugador sin cambios en la altura
            transform.Translate(valueXAxis, 0f, valueZAxis);

        } else if(Input.GetButton("Fire1") && !isMoving){
            //Activamos movimiento
            isMoving = true;
        }else if (Input.GetButton("Fire1") && isMoving){
            //Desactivamos movimiento
            isMoving = false;
        }
    }
}
