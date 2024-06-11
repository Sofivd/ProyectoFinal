using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonVale : MonoBehaviour
{
    public GameObject interfaz;
    public GameObject mensajeInicio;

    public bool mensaje;
    void Start()
    {
        mensaje = true;
        interfaz.SetActive(false);
        Time.timeScale = 0;
    }
    void Update()
    {
        
    }

    public void Entendido()
    {
        mensaje = false;
        interfaz.SetActive(true);
        mensajeInicio.SetActive(false);
        Time.timeScale = 1;
    }
}
