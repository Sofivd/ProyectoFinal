using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonMensaje : MonoBehaviour
{
    public GameObject panelAyuda;
    public GameObject menuPausa;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    public void Mensaje()
    {
        panelAyuda.SetActive(true);
        menuPausa.SetActive(false);
    }
}
