using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ContadorRollitos : MonoBehaviour
{
    public TextMeshProUGUI Contador;

    int rollitos = 0;
    public int numeroRollitos = 0;

    public GameObject rollitosCanela;
    public GameObject cinnamon;
    public GameObject plataformasFinales;

    public bool maxRollitos = false;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Contador.text = "X " + rollitos;

        if (numeroRollitos == 20)
        {
            maxRollitos = true;
        }
        if(maxRollitos == true) 
        {
            plataformasFinales.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if( other.gameObject.tag == "Rollito")
        {
            rollitos = rollitos + 1;
            Contador.text = rollitos.ToString();
            Destroy(other.gameObject);
            numeroRollitos = numeroRollitos + 1;

        }
    }
}
