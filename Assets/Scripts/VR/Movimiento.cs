using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1")){
            Debug.Log("Touch detected");
            transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
            Debug.Log(Camera.main.transform.forward);
        }
    }
}
