using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject botonJugar;
    public GameObject Cinematica;
    public GameObject Cinematica2;
    void Start()
    {
        Invoke("SegundaCinematica", 13f);
    }
    void Update()
    {
        
    }
    public void SegundaCinematica()
    {
        Cinematica2.SetActive(true);
        botonJugar.SetActive(true);
        Cinematica.SetActive(false);
    }
}
