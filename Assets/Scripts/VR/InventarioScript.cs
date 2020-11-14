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


    public async void ActivarCuenta(){
        Task waitToDeleteText =  Task.Delay((int)segundosEspera * 1000);
        await waitToDeleteText;
        if(textoInventario != null){
        textoInventario.text = "";
        }
        inventarioBloqueado = false;
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
            CambiarTexto("Objeto añadido al inventario");
        }else{
            CambiarTexto("Inventario lleno");
        }
        }
    }
}
