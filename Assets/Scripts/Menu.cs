using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MenuPausa;

    public bool juegoPausado;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { 
            MenuPausa.SetActive(true);
            Time.timeScale = 0;
            juegoPausado = true;
        }
    }
}
