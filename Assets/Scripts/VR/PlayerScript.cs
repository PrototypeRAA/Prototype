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

    public AudioSource gameOverAudio;
    public bool isGameOver;
    
    void Start()
    {
        inventario = (InventarioScript) FindObjectOfType(typeof(InventarioScript));
        anim = blackImage.GetComponent<Animator>();
        StartCoroutine(FadeIn());
        isGameOver = false;
    }


    IEnumerator FadeIn(){
        anim.SetBool("fadeIn", true);
        yield return new WaitUntil(()=> blackImage.color.a == 0);
    }

    IEnumerator FadeOut(){
       anim.SetBool("fadeOut", true);
       yield return new WaitUntil(()=> blackImage.color.a == 1);
    }


    public async void GameOver(){
        gameOverAudio.PlayOneShot(gameOverAudio.clip);
        StartCoroutine(FadeOut());
        Task waitForSceneReload =  Task.Delay(2000);
        await waitForSceneReload;
        SceneManager.LoadScene("Nivel 1");
    }

    
    public async void GameOverLevel2(){
        gameOverAudio.PlayOneShot(gameOverAudio.clip);
        StartCoroutine(FadeOut());
        Task waitForSceneReload =  Task.Delay(2000);
        await waitForSceneReload;
        SceneManager.LoadScene("Nivel 2");
    }

    public async void TransitionToNextLevel(){
         StartCoroutine(FadeOut());
        Task waitForSceneReload =  Task.Delay(3000);
        await waitForSceneReload;
        SceneManager.LoadScene("Nivel 2");
    }




}
