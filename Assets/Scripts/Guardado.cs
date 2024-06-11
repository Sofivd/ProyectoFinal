using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardado : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void GuardarRollitos(int rollitos)
    {
        PlayerPrefs.SetInt("RollitoCanela", rollitos);
        PlayerPrefs.Save();
    }
    public int RecuperarRollitos()
    {
        int rollitosCogidos = PlayerPrefs.GetInt("RollitoCanela", 0);
        return rollitosCogidos;
    }
}
