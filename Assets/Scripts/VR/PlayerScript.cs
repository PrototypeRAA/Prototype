using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading.Tasks;
public class PlayerScript : MonoBehaviour
{
    public InventarioScript inventario;

    public Image blackImage;

    public Animator anim;
    
    void Start()
    {
        inventario = (InventarioScript) FindObjectOfType(typeof(InventarioScript));
        anim = blackImage.GetComponent<Animator>();
        StartCoroutine(FadeIn());
    }


    IEnumerator FadeIn(){
        anim.SetBool("fadeIn", true);
        yield return new WaitUntil(()=> blackImage.color.a == 0);
    }

    public async void GameOver(){
        StartCoroutine(FadeOut());
        Task waitForSceneReload =  Task.Delay(2000);
        await waitForSceneReload;
        SceneManager.LoadScene("Nivel 1");
    }

   IEnumerator FadeOut(){
       anim.SetBool("fadeOut", true);
       yield return new WaitUntil(()=> blackImage.color.a == 1);
    }



}
