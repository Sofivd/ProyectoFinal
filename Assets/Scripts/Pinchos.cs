using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{
    Vector3 comienzo;

    float tiempo = 10f;
    float tiempoActivo = 12f;
    float tiempoInActivo = 20f;

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
        tiempo = tiempo - Time.deltaTime;

 
        if (tiempo <= 0f)
        {
            //¿en que estado estamos?
            // ¿pinchos fuera? ¿sacarPinchos == true?

                // meter los pinchos.
                // tiempo = 5;

            // ¿pinchos dentro?
                // sacar los pinchos.
                // tiempo = 5

            if(sacarPinchos == false)
            {
                tiempo = tiempoActivo;
                foreach (Transform t in transform)
                {
                    t.gameObject.SetActive(false);
                }
                sacarPinchos = true;
                
     
            }
            
           else if (sacarPinchos == true)
            {
                tiempo = tiempoInActivo;
                foreach (Transform t in transform)
                {
                    t.gameObject.SetActive(true);
                }
                sacarPinchos= false;
                
            }


        
        }


        
       
    }

  
}
