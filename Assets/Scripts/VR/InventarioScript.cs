using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class InventarioScript : MonoBehaviour
{
    public GameObject objetoEnInventario = null;

    public Text textoInventario;

    public float segundosEspera;
    
    public bool inventarioBloqueado = false;

    // Start is called before the first frame update
    void Start()
    {
        segundosEspera = 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void ActivarCuenta(){
        Task waitToDeleteText =  Task.Delay((int)segundosEspera * 1000);
        await waitToDeleteText;
        if(textoInventario != null){
        textoInventario.text = "";
        }
        inventarioBloqueado = false;
        Debug.Log("ya fuera");
    }

    public void CambiarTexto(String nuevoTexto){
        textoInventario.text = nuevoTexto;
        inventarioBloqueado = true;
        ActivarCuenta();
    }

    public void NuevoObjetoEnInventario(GameObject objetoParaInventario){
        if(!inventarioBloqueado){
        if(objetoEnInventario == null){
            objetoEnInventario = objetoParaInventario;
            Debug.Log(objetoParaInventario);
            Debug.Log("Objeto añadido al inventario");
            CambiarTexto("Objeto añadido al inventario");
        }else{
            Debug.Log("Inventario lleno");
            CambiarTexto("Inventario lleno");
        }
        }
    }
}
