using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    Vector3 comienzo;
    float tiempo = 5f;
    bool sacarPinchos;
    public GameObject pinchos;
    // Aparecer y desaparecer pinchos
    void Start()
    {
       sacarPinchos = true;
        gameObject.SetActive(true);
    }

    
    void Update()
    {
        sacarPinchos = true;

        if (tiempo == 5)
            {
               gameObject.SetActive(true);
               sacarPinchos = true;

            }

             if(sacarPinchos == true)
            {
               tiempo = tiempo - Time.deltaTime;
            }

            if(tiempo <= 3)
            {
              gameObject.SetActive(false);
              tiempo = 5f;
              sacarPinchos=true;
            
            //sacarPinchos = true;

        }
        Debug.Log("El tiempo es: " + tiempo);
        
       
    }

  
}
