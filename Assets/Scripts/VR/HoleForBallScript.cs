using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleForBallScript : MonoBehaviour
{

    public GameObject theOtherHole;

    public bool isFilled;

    public string ownTag;

    public GameObject puertaSala4;

    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
        ownTag = gameObject.tag;
    }

     public void OnTriggerEnter(Collider col){
       
        if(col.tag == "BlueBall" && ownTag == "BlueHole"){
            isFilled = true;
            CheckOtherHole();
        }
        else if(col.tag == "RedBall" && ownTag == "RedHole"){
            isFilled = true;
            CheckOtherHole();
        }
    }


    public void CheckOtherHole(){
        HoleForBallScript scriptFromOtherHole = theOtherHole.GetComponent<HoleForBallScript>();
        if(scriptFromOtherHole.isFilled){
            AbrirPuertaSala4();
        }
    }

    public void AbrirPuertaSala4(){
        
    }

}
