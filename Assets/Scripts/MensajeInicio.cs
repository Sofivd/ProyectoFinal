using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajeInicio : MonoBehaviour
{
    public GameObject mensaje;
    public GameObject interfaz;

    public bool panelAyuda = true;


    void Start()
    {
        
    }

    
    void Update()
    {
        if(panelAyuda == true)
        {
            Time.timeScale = 0f;
            interfaz.SetActive(false);
        }
        else if (panelAyuda == false)
        {
            Time.timeScale = 1.0f;
            interfaz.SetActive(true);
        }
    }

    public void botonEntendido()
    {
        mensaje.SetActive(false);
        Time.timeScale = 1.0f;
        panelAyuda = false;
        interfaz.SetActive(true);
    }
}
