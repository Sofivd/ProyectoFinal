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
       //sacarPinchos = true;
        //gameObject.SetActive(true);
    }

    
    void Update()
    {
        gameObject.SetActive(true);
        //sacarPinchos = true;

        if (tiempo == 5f)
            {
               //gameObject.SetActive(true);
               sacarPinchos = true;

            }

             if(sacarPinchos == true)
            {
               tiempo = tiempo - Time.deltaTime;
               gameObject.SetActive(true);
            }

            if(tiempo <= 3)
            {
              gameObject.SetActive(false);
              tiempo = 5f;
              sacarPinchos= false;
            
            //sacarPinchos = true;

        }
        Debug.Log("El tiempo es: " + tiempo);
        
       
    }

  
}
