using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenClose : MonoBehaviour
{
    public Animator animator;
    public void open(){
        if(animator.GetBool("isOpen") == true){
            animator.SetBool("isOpen", false);
        }
        else{
            animator.SetBool("isOpen", true);
        }
    }
}
