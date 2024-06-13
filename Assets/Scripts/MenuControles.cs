using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControles : MonoBehaviour
{
    public GameObject panelMando;
    public GameObject panelTeclado;
    public GameObject mensajeInicio;
    public GameObject panelAzul;

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
        panelAzul.SetActive(true);
    }

    public void Teclado()
    {
        panelTeclado.SetActive(true);
        mensajeInicio.SetActive(false);
        panelAzul.SetActive(true);
    }
    public void SalirControles()
    {
        mensajeInicio.SetActive(true);
        panelMando.SetActive(false);
        panelTeclado.SetActive(false);
        panelAzul.SetActive(false);
    }
}
