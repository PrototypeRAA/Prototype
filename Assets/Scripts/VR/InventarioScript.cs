using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventarioScript : MonoBehaviour
{
    public GameObject objetoEnInventario;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NuevoObjetoEnInventario(GameObject objetoParaInventario){
        if(Object.ReferenceEquals(objetoEnInventario,null)){
            objetoEnInventario = objetoParaInventario;
            Debug.Log(objetoParaInventario);
            Debug.Log("Objeto añadido al inventario");
        }else{
            Debug.Log("Inventario lleno");
        }
    }
}
