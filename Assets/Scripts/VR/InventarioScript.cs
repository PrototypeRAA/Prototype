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
        segundosEspera = 4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    async void ActivarCuenta(){
        await Task.Delay(4000);
        textoInventario.text = "";
        inventarioBloqueado = false;
    }

    public void NuevoObjetoEnInventario(GameObject objetoParaInventario){
        if(!inventarioBloqueado){
        if(objetoEnInventario == null){
            objetoEnInventario = objetoParaInventario;
            Debug.Log(objetoParaInventario);
            Debug.Log("Objeto añadido al inventario");
            textoInventario.text = "Objeto añadido al inventario";
        }else{
            Debug.Log("Inventario lleno");
            textoInventario.text = "Inventario lleno";
        }
        inventarioBloqueado = true;
        ActivarCuenta();
        }
    }
}
