using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ContadorRollitos : MonoBehaviour
{
    public TextMeshProUGUI Contador;

    int rollitos = 0;

    public GameObject rollitosCanela;
    public GameObject cinnamon;
    public GameObject plataformasFinales;
   

    public PlatFinales platFinales;

    public bool maxRollitos = false;
 
    public void CuentaUnRollito()
    {
        rollitos = rollitos + 1;
        Contador.text = "X " + rollitos.ToString();
        
        if (rollitos == 20)
          {
            maxRollitos = true;
           platFinales.AscenderPlat();
          }
    }
}
