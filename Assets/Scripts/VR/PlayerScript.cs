using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public InventarioScript inventario;
    // Start is called before the first frame update
    void Start()
    {
        inventario = (InventarioScript) FindObjectOfType(typeof(InventarioScript));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
