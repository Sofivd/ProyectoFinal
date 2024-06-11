using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControles : MonoBehaviour
{
    public GameObject panelMando;
    public GameObject panelTeclado;
    public GameObject mensajeInicio;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
    public void Mando()
    {
        panelMando.SetActive(true);
        mensajeInicio.SetActive(false);
    }

    public void Teclado()
    {
        panelTeclado.SetActive(true);
        mensajeInicio.SetActive(false);
    }
    public void SalirControles()
    {
        mensajeInicio.SetActive(true);
        panelMando.SetActive(false);
        panelTeclado.SetActive(false);
    }
}
