using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour
{
    public GameObject MenuPrincipal;
    public GameObject Interfaz;

    public bool Inicio = true;

    private void Start()
    {
        if(Inicio == true)
        {
            Time.timeScale = 0;
        }
    }
    public void Iniciar()
    {
        MenuPrincipal.SetActive(false);
        Interfaz.SetActive(true);
        Inicio = false;
        Time.timeScale = 1;
    }
}
