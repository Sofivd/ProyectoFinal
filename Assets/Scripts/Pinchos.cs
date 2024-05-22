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
      

            if(tiempo == 5)
            {
               gameObject.SetActive(true);
            sacarPinchos = true;

        }
            if(tiempo <= 1)
            {
              gameObject.SetActive(false);
              tiempo = 5f;
            
            //sacarPinchos = true;

        }
        Debug.Log("El tiempo es: " + tiempo);
        if(sacarPinchos == true)
        {
          tiempo = tiempo - Time.deltaTime;
        }
       
    }

  
}
